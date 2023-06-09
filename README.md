# Roblox-Patcher
Allows you to modify your cursor, death sound, and config for ROBLOX.
Config settings currently include: Setting FPS cap/Unlocking, Enabling all 21 graphics settings, and enabling Vulkan API.
When changing files in the Assets folder, make sure they have the same name and file extension.

heres how to create a config file for the game:
Step 1: navigate to your roblox folder, this can be in appdata/local or program files(86x)
step 2: goto versions and the roblox folder, its usually named something like version-21bedf9513a74867
step 3: create a folder named ClientSettings ![image](https://github.com/StealthDrifter/Roblox-Patcher/assets/53316578/1d274a43-bf6d-47ed-8e3b-07d3b0415014)
step 4: inside this folder, create a file named ClientAppSettings.json ![image](https://github.com/StealthDrifter/Roblox-Patcher/assets/53316578/1cb3f02a-9cd5-49e6-8a33-23879849f70d)
step 5: Open the json file with notepad copy paste this

 {
"DFIntTaskSchedulerTargetFps": 200000000,
}

Note that doesn't have to be the number, do what ever number you want it to max out at I did 220

step 6: save and open roblox
you can change the number to anything
