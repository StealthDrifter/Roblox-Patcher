using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Roblox_Patcher
    {
        public static bool modifyCursor = false;
        public static bool modifyDeathSound = false;
        public static bool modifyFps = false;
        public static bool modifyAll = false;

        public static void Start()
        {
            FindRoblox();
        }

        private static void FindRoblox()
        {

            bool safeToRun = true;
            DirectoryInfo Di = new DirectoryInfo($"C:\\Users\\{Environment.UserName}\\AppData\\Local\\Roblox\\Versions");
            try
            {
                DirectoryInfo[] DiArr = Di.GetDirectories();
            }
            catch
            {
                Di = new DirectoryInfo("C:\\Program Files (x86)\\Roblox\\Versions");
                try
                {
                    DirectoryInfo[] DiArr = Di.GetDirectories();
                }
                catch
                {
                    string message = "Roblox was not detected on this computer";
                    string caption = "Failure! :(";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    Console.WriteLine("Roblox is not installed on this computer.");
                    safeToRun = false;
                }
            }
            int counting = 0;
            DateTime[] folderAges = new DateTime[3];
            string[] folderNames = new string[3];
            if (safeToRun)
            {
                DirectoryInfo[] diArr = Di.GetDirectories();
                if (diArr.Length > 1)
                {
                    Console.WriteLine("Checking folders in directory");
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
                            Modify(folderNames[0]);
                            break;

                        case false:
                            Modify(folderNames[1]);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("One folder Present");
                    foreach (DirectoryInfo dri in diArr)
                    {
                        Modify(dri.FullName);
                    }
                }
            }
        }

        private static void Modify(string folderName)
        {
            if (modifyDeathSound || modifyAll)
            {
                string newSoundFile = ".\\Assets\\ouch.ogg";
                string oldSoundFile = folderName + "\\content\\sounds\\ouch.ogg";
                string clonedNewSoundFile = ".\\Assets\\ouch2.ogg";
                Console.WriteLine("Modifying Sound File");
                if (File.Exists(oldSoundFile))
                {
                    File.Delete(oldSoundFile); // deletes old sound file
                }
                File.Copy(newSoundFile, clonedNewSoundFile); // clones desired sound file
                File.Move(newSoundFile, oldSoundFile); // replaces old sound file with desired sound file
                File.Move(clonedNewSoundFile, newSoundFile); // Renames cloned desired sound file for later use
                Console.WriteLine("Finished modifying Death Sound");
            }
            if (modifyCursor || modifyAll)
            {
                string newFarCursor = ".\\Assets\\ArrowFarCursor.png";
                string newArrowCursor = ".\\Assets\\ArrowCursor.png";
                string clonedNewFarCursor = ".\\Assets\\ArrowFarCursor2.png";
                string clonedNewArrowCursor = ".\\Assets\\ArrowCursor2.png";
                string oldFarCursor = folderName + "\\content\\textures\\Cursors\\KeyboardMouse\\ArrowFarCursor.png";
                string oldArrowCursor = folderName + "\\content\\textures\\Cursors\\KeyboardMouse\\ArrowCursor.png";
                Console.WriteLine("Modifying Cursor Files");
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
                Console.WriteLine("Finished modifying Cursor");
            }

            if (modifyFps || modifyAll)
            {
                string newConfig = ".\\Assets\\ClientAppSettings.json";
                string oldConfig = folderName + "\\ClientSettings\\ClientAppSettings.json";
                string clonedNewConfig = ".\\Assets\\ClientAppSettings2.json";
                Console.WriteLine("Modifying config");
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
                Console.WriteLine("Finished modifying Config");
            }
            Console.WriteLine("\nFinished modifying game files");
            Console.WriteLine();
            string message = "Roblox has been modified!";
            string caption = "Success!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
        }
    }
}
