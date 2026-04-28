using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using WinFormsApp1;

namespace Roblox_Patcher
{
    internal class Listener
    {

        private FileSystemWatcher? watcher;
        public async Task RobloxListener(TextBox Logs) 
        {
            Logs.Invoke(() =>
            {
                Logs.Text += "Starting Roblox Listener..." + Environment.NewLine;
            });
            //WqlEventQuery query = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 1 WHERE TargetInstance.Name = 'RobloxPlayerInstaller.exe'");
            //ManagementEventWatcher watcher = new ManagementEventWatcher();

            /*ManagementEventWatcher watcher = new ManagementEventWatcher(
            new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace WHERE ProcessName = 'RobloxPlayerInstaller.exe'")
            );

            Logs.Text += "Monitoring for Roblox Process..." + Environment.NewLine;
            watcher.EventArrived += (s, e) =>
            {
                Logs.Invoke(() =>
                {
                    Logs.Text += "Roblox Process Detected" + Environment.NewLine;
                    Program.Start(Logs);
                });
            };
            watcher.Start();
            await Task.Delay(-1);
            */
            if (!TryFindRoblox(out string robloxPath, Logs))
            {
                Logs.Invoke (() =>
                {
                    Logs.Text += "Roblox not found, listener exiting..." + Environment.NewLine;
                });
                return;
            }
            watcher = new FileSystemWatcher(robloxPath)
            {
                IncludeSubdirectories = false,
                EnableRaisingEvents = true,
            };

            watcher.Created += (s, e) =>
            {
                if (e.Name.StartsWith("version-"))
                {
                    Logs.Invoke(() =>
                    {
                        Logs.Text += $"Roblox Update Detected: {e.FullPath}" + Environment.NewLine;
                    });
                    Thread.Sleep(1000);
                    Program.Start(Logs);
                }
            };
            await Task.Delay(-1);
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
                    robloxPath = adminPath;
                    return true;
                }
                robloxPath = userPath;
                return true;
            }
            catch (Exception ex)
            {
                Logs.Invoke(() =>
                {
                    Logs.Text += $"Error finding Roblox: {ex.Message}" + Environment.NewLine;
                });
                robloxPath = "invalid";
                return false;
            }
        }
    }
}
