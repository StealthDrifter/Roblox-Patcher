using Microsoft.VisualBasic.Logging;
using Roblox_Patcher;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WinFormsApp1
{
    internal static class Program
    {

        public static bool modifyCursor = false;
        public static bool modifyDeathSound = false;
        public static bool modifyConfig = false;
        public static bool vulkan = false;
        public static bool allGraphics = false;
        public static int fps = 0;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static void Start(TextBox Logs)
        {
            if (!TryFindRoblox(out var robloxPath, Logs))
            {
                Logs.Text += "Roblox was not detected on this computer" + Environment.NewLine;
                MessageBox.Show("Roblox was not detected on this computer", "Failure! :(", MessageBoxButtons.OK);
                return;
            }

            if (modifyConfig && !ModifyConfig())
            {
                Logs.Text += "Missing config file in Assets" + Environment.NewLine;
                MessageBox.Show("Please create a ClientAppSettings.json in the Assets folder", "Failure! :(", MessageBoxButtons.OK);
                return;
            }

            if (!TryModify(robloxPath, Logs))
            {
                Logs.Text += "Something went horribly wrong" + Environment.NewLine;
                MessageBox.Show("Oops! something went wrong! contact developer", "Failure! :(", MessageBoxButtons.OK);
                return;
            }
            Logs.Text += "Finished modifying game files" + Environment.NewLine;
            MessageBox.Show("Roblox has been modified!", "Success!", MessageBoxButtons.OK);
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
                        Logs.Text += "One folder Present" + Environment.NewLine;
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
                        Logs.Text += "Checking folders in directory" + Environment.NewLine;
                        foreach (DirectoryInfo dri in diArr)
                        {
                            if (!File.Exists(Path.Combine(dri.FullName, "RobloxStudioBeta.exe")) && File.Exists(Path.Combine(dri.FullName, "RobloxPlayerBeta.exe")))
                            {
                                DateTime dt = Directory.GetCreationTime(dri.FullName);
                                folderData.Add(new FolderData() { folderAge = dt, folderDirectory = dri.FullName});
                            }
                        }
                        robloxPath = folderData.MaxBy(FolderData => FolderData.folderAge).folderDirectory;
                        return true;
                }
            } catch (Exception ex)
            { 
                Console.WriteLine(ex.ToString());
                Logs.Text += ex.ToString() + Environment.NewLine;
                robloxPath = "invalid";
                return false;
            }
            robloxPath = "invalid";
            return false;
        }

        private static bool ModifyConfig()
        {
            if (!File.Exists(@".\Assets\ClientAppSettings.json")) {
                return false;
            }
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            Config config = new Config
            {
                DFIntTaskSchedulerTargetFps = fps.ToString(),
                FFlagDebugGraphicsPreferVulkan = vulkan,
                FFlagFixGraphicsQuality = allGraphics,
            };
            string configFilePath = @".\Assets\ClientAppSettings.json";
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
                    string newSoundFile = @".\Assets\ouch.ogg";
                    string oldSoundFile = Path.Combine(folderName, @"content\sounds\ouch.ogg");
                    Logs.Text += "Modifying Sound File" + Environment.NewLine;

                    File.Copy(newSoundFile, oldSoundFile, true); // replaces old sound file with desired sound file
                    Logs.Text += "Finished modifying Death Sound" + Environment.NewLine;
                }
                if (modifyCursor)
                {
                    string newFarCursor = @".\Assets\ArrowFarCursor.png";
                    string newArrowCursor = @".\Assets\ArrowCursor.png";
                    string oldFarCursor = Path.Combine(folderName, @"content\textures\Cursors\KeyboardMouse\ArrowFarCursor.png");
                    string oldArrowCursor = Path.Combine(folderName, @"content\textures\Cursors\KeyboardMouse\ArrowCursor.png");
                    Logs.Text += "Modifying Cursor Files" + Environment.NewLine;

                    File.Copy(newFarCursor, oldFarCursor, true);
                    File.Copy(newArrowCursor, oldArrowCursor, true);
                    Logs.Text += "Finished modifying Cursor" + Environment.NewLine;
                }
                if (modifyConfig)
                {
                    string newConfig = @".\Assets\ClientAppSettings.json";
                    string oldConfig = Path.Combine(folderName, @"ClientSettings\ClientAppSettings.json");
                    Logs.Text += "Modifying config" + Environment.NewLine;

                    if (!Directory.Exists(Path.Combine(folderName, "ClientSettings")))
                    {
                        Directory.CreateDirectory(Path.Combine(folderName, "ClientSettings"));
                    }
                    File.Copy(newConfig, oldConfig, true);
                    Logs.Text += "Finished modifying Config" + Environment.NewLine;
                }
            } catch
            {
                return false;
            }
            return true;
        }
    }
}