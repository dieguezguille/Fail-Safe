# What is it
Simple program that closes Visual Studio, looks for and deletes bin, obj &amp; .vs folders from the current directory. Useful when there is an IPv4 change and in consequence API development breaks. "Can't connect to IIS Express" error. Saves some time :)

# Usage
Grab the FailSafe.exe file from the bin\Release folder. Place it in the directory you want it to work on (let's say your local API repo). It will go into every subdirectory and ask you for confirmation to delete bin, obj and .vs directories. This is the first step for fixing the IIS Express issue in Visual Studio.
After that you'll need to reopen VS as Administrator and right-click on your project then Properties, Debug and change the IP address to the new one. Save, Run, and you should be ready to go again.
