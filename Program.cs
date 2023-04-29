using Microsoft.VisualBasic.Logging;

namespace WinFormsApp1
{
    internal static class Program
    {

        public static bool modifyCursor = false;
        public static bool modifyDeathSound = false;
        public static bool modifyFps = false;
        public static bool modifyAll = false;

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
                string message = "Roblox was not detected on this computer";
                string caption = "Failure! :(";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                _ = MessageBox.Show(message, caption, buttons);
                return;
            }

            if (!TryModify(robloxPath, Logs))
            {
                Logs.Text += "\nSomething went horribly wrong" + Environment.NewLine;
                string message3 = "Oops! something went wrong! contact developer";
                string caption3 = "Failure! :(";
                MessageBoxButtons buttons3 = MessageBoxButtons.OK;
                _ = MessageBox.Show(message3, caption3, buttons3);
                return;
            }
            Logs.Text += "\nFinished modifying game files" + Environment.NewLine;
            string message2 = "Roblox has been modified!";
            string caption2 = "Success!";
            MessageBoxButtons buttons2 = MessageBoxButtons.OK;
            _ = MessageBox.Show(message2, caption2, buttons2);
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
                int counting = 0;
                DateTime[] folderAges = new DateTime[3];
                string[] folderNames = new string[3];
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
                            if (!File.Exists(Path.Combine(dri.FullName, "RobloxStudioBeta.exe")))
                            {
                                DateTime dt = Directory.GetCreationTime(dri.FullName);
                                folderNames[counting] = dri.FullName;
                                folderAges[counting] = dt;
                                counting += 1;
                            }
                        }
                        bool firstOrSecond = folderAges[0] > folderAges[1];
                        switch (firstOrSecond)
                        {
                            case true:
                                robloxPath = folderNames[0];
                                return true;

                            case false:
                                robloxPath = folderNames[1];
                                return true;
                        }
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

        private static bool TryModify(string folderName, TextBox Logs)
        {
            try
            {
                if (modifyDeathSound || modifyAll)
                {
                    string newSoundFile = @".\Assets\ouch.ogg";
                    string oldSoundFile = Path.Combine(folderName, @"content\sounds\ouch.ogg");
                    Logs.Text += "Modifying Sound File" + Environment.NewLine;

                    File.Copy(newSoundFile, oldSoundFile, true); // replaces old sound file with desired sound file
                    Logs.Text += "Finished modifying Death Sound" + Environment.NewLine;
                }
                if (modifyCursor || modifyAll)
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

                if (modifyFps || modifyAll)
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