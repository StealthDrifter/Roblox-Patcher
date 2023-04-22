using System.IO;

internal class Program
{

    static bool modifyDeathSound = false;
    static bool modifyCursor = false;
    static bool modifyFps = false;
    static bool modifyAll = false;
    private static void Main(string[] args)
    {
        bool haventChosen = true;
        while (haventChosen == true)
        {
            Console.Clear();
            Console.WriteLine("What would you like to modify?");
            Console.WriteLine("0. Close program\n1. Cursor\n2. Death Sound\n3. Unlock FPS\n4. All of the above");
            Console.Write("Enter your option: ");
            if (int.TryParse(Console.ReadLine(), out int ans))
            {
                switch (ans)
                {
                    case 0:
                        haventChosen= false;
                        break;

                    case 1:
                        modifyCursor = true;
                        haventChosen = false;
                        FindRoblox();
                        break;

                    case 2:
                        modifyDeathSound = true;
                        haventChosen = false;
                        FindRoblox();
                        break;

                    case 3:
                        modifyFps = true;
                        haventChosen = false;
                        FindRoblox();
                        break;

                    case 4:
                        modifyAll = true;
                        haventChosen = false;
                        FindRoblox();
                        break;
                }
            }
        }
    }
    private static void FindRoblox()
    {
        bool safeToRun = true;
        DirectoryInfo Di = new DirectoryInfo($"C:\\Users\\{Environment.UserName}\\AppData\\Local\\Roblox\\Versions");
        try
        {
            DirectoryInfo[] DiArr = Di.GetDirectories();
        } catch
        {
            Di = new DirectoryInfo("C:\\Program Files (x86)\\Roblox\\Versions");
            try
            {
                DirectoryInfo[] DiArr = Di.GetDirectories();
            } catch 
            {
                Console.WriteLine("Roblox is not installed on this computer.");
                Console.ReadKey(true);
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
        Console.WriteLine("Press any key to exit");
        Console.ReadKey(true);
    }   
}