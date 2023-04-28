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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
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

            if (!Modify(robloxPath, Logs))
            {
                Logs.Text += "\nSomething went horribly wrong" + Environment.NewLine;
                string message3 = "Oops! something went wrong! contact developer";
                string caption3 = "Failure! :(";
                MessageBoxButtons buttons3 = MessageBoxButtons.OK;
                _ = MessageBox.Show(message3, caption3, buttons3);
            }
            Logs.Text += "\nFinished modifying game files" + Environment.NewLine;
            Console.WriteLine();
            string message2 = "Roblox has been modified!";
            string caption2 = "Success!";
            MessageBoxButtons buttons2 = MessageBoxButtons.OK;
            _ = MessageBox.Show(message2, caption2, buttons2);
        }

        private static bool TryFindRoblox(out string robloxPath, TextBox Logs)
        {
            string adminPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86);
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DirectoryInfo Di = new DirectoryInfo($"{userPath}\\Roblox\\Versions");
            try
            {
                DirectoryInfo[] DiArr = Di.GetDirectories();
            }
            catch
            {
                Di = new DirectoryInfo($"{adminPath}\\Roblox\\Versions");
                try
                {
                    DirectoryInfo[] DiArr = Di.GetDirectories();
                }
                catch
                {
                    robloxPath = "invalid";
                    return false;
                }
            }
            int counting = 0;
            DateTime[] folderAges = new DateTime[3];
            string[] folderNames = new string[3];
            DirectoryInfo[] diArr = Di.GetDirectories();
            if (diArr.Length > 1)
            {
                Logs.Text += "Checking folders in directory" + Environment.NewLine;
                foreach (DirectoryInfo dri in diArr)
                {
                    if (!File.Exists(dri.FullName + "\\RobloxStudioBeta.exe"))
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
            else
            {
                Logs.Text += "One folder Present" + Environment.NewLine;
                foreach (DirectoryInfo dri in diArr)
                {
                    robloxPath = dri.FullName;
                    return true;
                }
            }
            robloxPath = "invalid";
            return false;
        }

        private static bool Modify(string folderName, TextBox Logs)
        {
            try
            {
                if (modifyDeathSound || modifyAll)
                {
                    string newSoundFile = ".\\Assets\\ouch.ogg";
                    string oldSoundFile = folderName + "\\content\\sounds\\ouch.ogg";
                    string clonedNewSoundFile = ".\\Assets\\ouch2.ogg";
                    Logs.Text += "Modifying Sound File" + Environment.NewLine;
                    if (File.Exists(oldSoundFile))
                    {
                        File.Delete(oldSoundFile); // deletes old sound file
                    }
                    File.Copy(newSoundFile, clonedNewSoundFile); // clones desired sound file
                    File.Move(newSoundFile, oldSoundFile); // replaces old sound file with desired sound file
                    File.Move(clonedNewSoundFile, newSoundFile); // Renames cloned desired sound file for later use
                    Logs.Text += "Finished modifying Death Sound" + Environment.NewLine;
                }
                if (modifyCursor || modifyAll)
                {
                    string newFarCursor = ".\\Assets\\ArrowFarCursor.png";
                    string newArrowCursor = ".\\Assets\\ArrowCursor.png";
                    string clonedNewFarCursor = ".\\Assets\\ArrowFarCursor2.png";
                    string clonedNewArrowCursor = ".\\Assets\\ArrowCursor2.png";
                    string oldFarCursor = folderName + "\\content\\textures\\Cursors\\KeyboardMouse\\ArrowFarCursor.png";
                    string oldArrowCursor = folderName + "\\content\\textures\\Cursors\\KeyboardMouse\\ArrowCursor.png";
                    Logs.Text += "Modifying Cursor Files" + Environment.NewLine;
                    if (File.Exists(oldFarCursor))
                    {
                        File.Delete(oldFarCursor);
                    }
                    if (File.Exists(oldArrowCursor))
                    {
                        File.Delete(oldArrowCursor);
                    }
                    File.Copy(newFarCursor, clonedNewFarCursor);
                    File.Copy(newArrowCursor, clonedNewArrowCursor);
                    File.Move(newFarCursor, oldFarCursor);
                    File.Move(newArrowCursor, oldArrowCursor);
                    File.Move(clonedNewFarCursor, newFarCursor);
                    File.Move(clonedNewArrowCursor, newArrowCursor);
                    Logs.Text += "Finished modifying Cursor" + Environment.NewLine;
                }

                if (modifyFps || modifyAll)
                {
                    string newConfig = ".\\Assets\\ClientAppSettings.json";
                    string oldConfig = folderName + "\\ClientSettings\\ClientAppSettings.json";
                    string clonedNewConfig = ".\\Assets\\ClientAppSettings2.json";
                    Logs.Text += "Modifying config" + Environment.NewLine;
                    if (!Directory.Exists(folderName + "\\ClientSettings"))
                    {
                        Directory.CreateDirectory(folderName + "\\ClientSettings");
                    }
                    if (File.Exists(oldConfig))
                    {
                        File.Delete(oldConfig);
                    }
                    File.Copy(newConfig, clonedNewConfig);
                    File.Move(newConfig, oldConfig);
                    File.Move(clonedNewConfig, newConfig);
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