# What is this?
This is directory cleaner - app, which silently deletes old files from your dirs.

# Installation
1. Build the app with *build.bat*, the result will be in *Build* directory;
2. Copy contents of *Build* directory to any directory you want the app to be;
3. Add directory with those files in PATH;
4. If you want the app to be started with Windows, add *DirectoryCleanerBackgroundWorkerStartupService* to autoruns;
5. Run *DirectoryCleaner help* to see available commands.

# Available commands
1. *help* - get all commands;
2. *add* - start tracking directory for old files
3. *stop-tracking* - stop tracking specified dir
4. *stop-tracking-all* - stop tracking all dirs
5. *update-global* - update global variables:  
    a) DeleteInterval  
    b) GlobalMaxLifeTime (is used when max file lifetime for files in dir is not specified)
6. *print-directories* - print directories that are being tracked    

# Current problems
The main problem is to reduce the size of executables, currently when I use trimming, the part of Settings class is being trimmed and I don't know how to fix this.