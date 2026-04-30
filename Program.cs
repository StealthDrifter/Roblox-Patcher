using Microsoft.VisualBasic.Logging;
using Microsoft.Win32;
using NAudio.CoreAudioApi;
using Roblox_Patcher;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using static System.Windows.Forms.Design.AxImporter;

namespace WinFormsApp1
{
    internal static class Program
    {
        public static event Action? ShowFormEvent;
        public static bool modifyCursor = false;
        public static bool modifyDeathSound = false;
        public static bool modifyConfig = false;
        public static bool vulkan = false;
        public static int volume = 100;
        public static bool setVolume = false;
        public static bool background = false;
        public static bool filesSafe = true;
        public static bool ListenerStarted = false;
        public static bool abandonShip = false;
        public static bool startup = false;
        private static readonly string assetsDirectory = Path.Combine(AppContext.BaseDirectory, "Assets");
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        public static void SetStartup(bool startup)
        {
            string appName = "RBXPatcher";
            string exePath = Application.ExecutablePath;

            using RegistryKey key = Registry.CurrentUser.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", 
                true);
            if (startup)
            {
                key.SetValue(appName, $"\"{exePath}\" --startup");
            } else
            {
                key.DeleteValue(appName, false);
            }
        }


        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, "RobloxPatcherMutex"))
            {
                if (!mutex.WaitOne(TimeSpan.Zero, false))
                {
                    IntPtr existingWindow = FindWindow(null, "RBXPatcher");
                    if (existingWindow != IntPtr.Zero)
                    {
                        ShowWindow(existingWindow, 9);
                        SetForegroundWindow(existingWindow);
                    }
                    return;
                }
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
        }

        public static void ShowMessage(TextBox Logs, string message, string title)
        {
            Logs.Invoke(() =>
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK);
            });
        }
        public static void AppendLog(TextBox Logs, string message)
        {
            Logs.Invoke(() =>
            {
                Logs.Text += message + Environment.NewLine;
            });
        }


        public static void Start(TextBox Logs)
        {
            while (filesSafe && !abandonShip)
            {
                if (!TryFindRoblox(out var robloxPath, Logs))
                {
                    ShowFormEvent?.Invoke();
                    AppendLog(Logs, "Roblox was not detected on this computer");
                    ShowMessage(Logs, "Roblox was not detected on this computer", "Failure! :(");
                    filesSafe = false;
                    continue;
                }

                if (!CheckFileSafety(Logs, robloxPath))
                {
                    continue;
                }

                if (!background)
                {
                    if (!ModifyDefaults(robloxPath))
                    {
                        ShowFormEvent?.Invoke();
                        AppendLog(Logs, "Missing defaults file in Assets");
                        ShowMessage(Logs, "Please create a Defaults.json in the Assets folder", "Failure! :(");
                        filesSafe = false;
                        continue;
                    }
                }

                if (modifyConfig && !ModifyConfig())
                {
                    ShowFormEvent?.Invoke();
                    AppendLog(Logs, "Missing config file in Assets");
                    ShowMessage(Logs, "Please create a ClientAppSettings.json in the Assets folder", "Failure! :(");
                    filesSafe = false;
                    continue;
                }

                if (!TryModify(robloxPath, Logs))
                {
                    ShowFormEvent?.Invoke();
                    AppendLog(Logs, "Something went horribly wrong");
                    ShowMessage(Logs, "Oops! something went wrong! contact developer", "Failure! :(");
                    filesSafe = false;  
                    continue;
                }
                AppendLog(Logs, "Finished modifying game files");

                if (setVolume && !SetVolume(volume, Logs))
                {
                    AppendLog(Logs, "Failed to set volume");
                    filesSafe = false;
                    continue;
                }

                if (!background) {
                ShowMessage(Logs, "Roblox has been modified!", "Success!"); }
                filesSafe = false;
            }
            AppendLog(Logs, "--------");
            filesSafe = true;
        }

        private static bool SetVolume(int volume, TextBox Logs)
        {
            using var deviceEnumerator = new MMDeviceEnumerator();
            var device = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            int attempts = 0;
            AppendLog(Logs, "Setting volume, program may look frozen. This is normal, Make sure to have roblox open.");
            while (attempts < 10)
            {
                AppendLog(Logs, "Attempting to set volume, Attempt #" + (attempts + 1));
                var sessions = device.AudioSessionManager.Sessions;
                for (int i = 0; i < sessions.Count; i++)
                {
                    var session = sessions[i];

                    try
                    {
                        int pid = (int)session.GetProcessID;
                        var process = Process.GetProcessById(pid);

                        if (process.ProcessName.Equals("RobloxPlayerBeta", StringComparison.OrdinalIgnoreCase))
                        {
                            session.SimpleAudioVolume.Volume = volume / 100f;
                            Console.WriteLine($"Set Roblox volume to {volume}%");
                            AppendLog(Logs, $"Set Roblox volume to {volume}%");
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                AppendLog(Logs, "Failed to set Audio, trying again, is roblox open?");
                attempts++;
                Thread.Sleep(3000); // wait a bit before trying again
            }
            AppendLog(Logs, "Failed to set volume after multiple attempts");
            return false;
        }

        private static bool TryFindRoblox(out string robloxPath, TextBox Logs)
        {
            try
            {
                string adminPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86), @"Roblox\Versions");
                string userPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Roblox\Versions");
                DirectoryInfo directory = new DirectoryInfo(userPath);
                if (!directory.Exists)
                {
                    directory = new DirectoryInfo(adminPath);
                    if (!directory.Exists)
                    {
                        robloxPath = "invalid";
                        return false;
                    }
                }
                List<FolderData> folderData = new List<FolderData>();
                // DateTime[] folderAges = new DateTime[3];
                // string[] folderNames = new string[3];
                DirectoryInfo[] diArr = directory.GetDirectories();
                switch (diArr.Length)
                {
                    case 0:
                        robloxPath = "invalid";
                        return false;

                    case 1:
                        AppendLog(Logs, "One folder Present");
                        foreach (DirectoryInfo dri in diArr)
                        {
                            if (!File.Exists(Path.Combine(dri.FullName, "RobloxStudioBeta.exe")))
                            {
                                robloxPath = dri.FullName;
                                return true;
                            }
                            else
                            {
                                robloxPath = "invalid";
                                return false;
                            }
                        }
                        robloxPath = "invalid";
                        return false;

                    case > 1:
                        AppendLog(Logs, "Checking folders in directory");
                        foreach (DirectoryInfo dri in diArr)
                        {
                            if (!File.Exists(Path.Combine(dri.FullName, "RobloxStudioBeta.exe")) && File.Exists(Path.Combine(dri.FullName, "RobloxPlayerBeta.exe")))
                            {
                                DateTime dt = Directory.GetCreationTime(dri.FullName);
                                folderData.Add(new FolderData() { FolderAge = dt, FolderDirectory = dri.FullName});
                            }
                        }
                        if (!folderData.Any())
                        {
                            robloxPath = "invalid";
                            return false;
                        }
                        robloxPath = folderData.MaxBy(FolderData => FolderData.FolderAge).FolderDirectory;
                        return true;
                }
            } catch (Exception ex)
            { 
                Console.WriteLine(ex.ToString());
                AppendLog(Logs, ex.ToString());
                robloxPath = "invalid";
                return false;
            }
            robloxPath = "invalid";
            return false;
        }

        private static bool CheckFileSafety(TextBox Logs, string robloxPath)
        {
            if (modifyDeathSound)
            {
                if (!File.Exists(Path.Combine(assetsDirectory, "oof.ogg")))
                {
                    ShowFormEvent?.Invoke();
                    AppendLog(Logs, "Missing oof sound file in Assets");
                    ShowMessage(Logs, "Please add an oof.ogg file to the Assets folder", "Failure! :(");
                    filesSafe = false;
                    return false;
                }
            }
            if (modifyCursor)
            {
                if (!File.Exists(Path.Combine(assetsDirectory, "ArrowFarCursor.png")) || !File.Exists(Path.Combine(assetsDirectory, "ArrowCursor.png")))
                {
                    ShowFormEvent?.Invoke();
                    AppendLog(Logs, "Missing cursor files in Assets");
                    ShowMessage(Logs, "Please add ArrowFarCursor.png and ArrowCursor.png files to the Assets folder", "Failure! :(");
                    filesSafe = false;
                    return false;
                }
            }
            if (modifyConfig)
            {
                if (!File.Exists(Path.Combine(assetsDirectory, "ClientAppSettings.json")))
                {
                    ShowFormEvent?.Invoke();
                    AppendLog(Logs, "Missing config file in Assets");
                    ShowMessage(Logs, "Please create a ClientAppSettings.json in the Assets folder", "Failure! :(");
                    filesSafe = false;
                    return false;
                }
            }

            if (background)
            {
                string defaultsFilePath = Path.Combine(assetsDirectory, "Defaults.json");
                if (!File.Exists(defaultsFilePath))
                {
                    ShowFormEvent?.Invoke();
                    AppendLog(Logs, "Missing defaults file in Assets");
                    ShowMessage(Logs, "Please create a Defaults.json in the Assets folder", "Failure! :(");
                    filesSafe = false;
                    return false;
                }
                Defaults defaults = JsonSerializer.Deserialize<Defaults>(File.ReadAllText(defaultsFilePath));
                if (defaults != null && !string.IsNullOrEmpty(defaults.RobloxDirectory))
                {
                    if (robloxPath == defaults.RobloxDirectory)
                    {
                        Console.WriteLine(defaults.RobloxDirectory);
                        Console.WriteLine(robloxPath);
                        AppendLog(Logs, "Roblox path is the same as the one in defaults, Waiting");
                        Thread.Sleep(5000);
                        if (!background)
                        {
                            abandonShip = true;
                            AppendLog(Logs, "Abandoning background patch");
                        }
                        filesSafe = true;
                        return false;
                    }
                }
                if (!FileExistsAndIsntLocked(Path.Combine(robloxPath, @"content\sounds\oof.ogg")) || !FileExistsAndIsntLocked(Path.Combine(robloxPath, @"content\textures\Cursors\KeyboardMouse\ArrowFarCursor.png")) || !FileExistsAndIsntLocked(Path.Combine(robloxPath, @"content\textures\Cursors\KeyboardMouse\ArrowCursor.png")))
                {
                    AppendLog(Logs, "One or more files are currently in use, Waiting");
                    Thread.Sleep(3000); 
                    if (!background)
                    {
                        abandonShip = true;
                        AppendLog(Logs, "Abandoning background patch");
                    }
                    filesSafe = true;
                    return false;
                }
                SetDefaults(robloxPath, Logs);
                AppendLog(Logs, "Updated Roblox Path in defaults");
            }
            AppendLog(Logs, "Files exist, continuing");
            filesSafe = false;
            return true;
        }

        private static bool FileExistsAndIsntLocked(string filePath)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    return stream.Length > 0; // Check if the file is not empty
                }
            }
            catch (IOException)
            {
                return false; // The file is locked or does not exist
            }
        }

        private static bool SetDefaults(string robloxPath, TextBox Logs)
        {
            string defaultsFilePath = Path.Combine(assetsDirectory, "Defaults.json");
            if (!File.Exists(defaultsFilePath))
            {
                return false;
            }
            Defaults defaults = JsonSerializer.Deserialize<Defaults>(File.ReadAllText(defaultsFilePath));
            if (defaults != null)
            {
                vulkan = defaults.vulkan;
                modifyConfig = defaults.modifyConfig;
                modifyCursor = defaults.modifyCursor;
                modifyDeathSound = defaults.modifyDeathSound;
                volume = defaults.volume;
                setVolume = defaults.setVolume;
                AppendLog(Logs, "Set options to defaults");
                ModifyDefaults(robloxPath);
                AppendLog(Logs, "Updated Roblox Path in defaults");
                return true;
            }
            if (!ModifyDefaults(robloxPath))
            {
                return false;
            }
            return true;
        }

        private static bool ModifyDefaults(string robloxPath)
        {
            string defaultsFilePath = Path.Combine(assetsDirectory, "Defaults.json");
            if (!File.Exists(defaultsFilePath))
            {
                return false;
            }
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            Defaults defaults = new Defaults
            {
                vulkan = vulkan,
                modifyConfig = modifyConfig,
                modifyCursor = modifyCursor,
                modifyDeathSound = modifyDeathSound,
                RobloxDirectory = robloxPath,
                volume = volume,
                setVolume = setVolume
            };
            string jsonString = JsonSerializer.Serialize(defaults, options);
            File.WriteAllText(defaultsFilePath, jsonString);
            return true;
        }

        private static bool ModifyConfig()
        {
            string configFilePath = Path.Combine(assetsDirectory, "ClientAppSettings.json");
            if (!File.Exists(configFilePath)) {
                return false;
            }
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            Config config = new Config
            {
                FFlagDebugGraphicsPreferVulkan = vulkan,
            };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(configFilePath, jsonString);

            return true;
        }

        private static bool TryModify(string folderName, TextBox Logs)
        {
            try
            {
                if (modifyDeathSound)
                {
                    string newSoundFile = Path.Combine(assetsDirectory, "oof.ogg");
                    string oldSoundFile = Path.Combine(folderName, @"content\sounds\oof.ogg");
                    AppendLog(Logs, "Modifying Sound File");

                    File.Copy(newSoundFile, oldSoundFile, true); // replaces old sound file with desired sound file
                    AppendLog(Logs, "Finished modifying Death Sound");
                }
                if (modifyCursor)
                {
                    string newFarCursor = Path.Combine(assetsDirectory, "ArrowFarCursor.png");
                    string newArrowCursor = Path.Combine(assetsDirectory, "ArrowCursor.png");
                    string oldFarCursor = Path.Combine(folderName, @"content\textures\Cursors\KeyboardMouse\ArrowFarCursor.png");
                    string oldArrowCursor = Path.Combine(folderName, @"content\textures\Cursors\KeyboardMouse\ArrowCursor.png");
                    AppendLog(Logs, "Modifying Cursor Files");

                    File.Copy(newFarCursor, oldFarCursor, true);
                    File.Copy(newArrowCursor, oldArrowCursor, true);
                    AppendLog(Logs, "Finished modifying Cursor");
                }
                if (modifyConfig)
                {
                    string newConfig = Path.Combine(assetsDirectory, "ClientAppSettings.json");
                    string oldConfig = Path.Combine(folderName, @"ClientSettings\ClientAppSettings.json");
                    AppendLog(Logs, "Modifying config");

                    if (!Directory.Exists(Path.Combine(folderName, "ClientSettings")))
                    {
                        Directory.CreateDirectory(Path.Combine(folderName, "ClientSettings"));
                    }
                    File.Copy(newConfig, oldConfig, true);
                    AppendLog(Logs, "Finished modifying Config");
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                AppendLog(Logs, ex.ToString());
                return false;
            }
            return true;
        }
    }
}
