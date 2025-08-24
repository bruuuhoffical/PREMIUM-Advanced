using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Bruuuh;
using MemoryAim2;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Visuals
{
    public class HiddenMenu
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();

        public HiddenMenu(Home mainForm)
        {
            _mainForm = mainForm;
        }

        private void Notify(string title, string message)
        {
            _mainForm.Invoke(new Action(() =>
            {
                _mainForm.Notify(title, message);
            }));
        }

        public void SetupHiddenMenu()
        {
            string resourceName = "PREMIUM_6._0.Properties.opengl32.dll"; 

            string[] emulatorFolders = new string[]
            {
                @"C:\Program Files\BlueStacks",           // Bluestacks 4
                @"C:\Program Files\BlueStacks_nxt",       // Bluestacks 5
                @"C:\Program Files\BlueStacks_msi2",      // MSI 4
                @"C:\Program Files\BlueStacks_msi5"       // MSI 5
            };

            foreach (string folder in emulatorFolders)
            {
                try
                {
                    if (!Directory.Exists(folder))
                    {
                        Notify("Skipped", $"Folder not found: {folder}");
                        continue;
                    }

                    string dllPath = Path.Combine(folder, "opengl32.dll");

                    Assembly executingAssembly = Assembly.GetExecutingAssembly();
                    using (Stream resourceStream = executingAssembly.GetManifestResourceStream(resourceName))
                    {
                        if (resourceStream == null)
                        {
                            Notify("Error", "Embedded resource not found: " + resourceName);
                            return;
                        }

                        using (FileStream fileStream = new FileStream(dllPath, FileMode.Create, FileAccess.Write))
                        {
                            byte[] buffer = new byte[resourceStream.Length];
                            resourceStream.Read(buffer, 0, buffer.Length);
                            fileStream.Write(buffer, 0, buffer.Length);
                        }

                        //Notify("Success", $"DLL deployed to {folder}");
                        Notify($"DLL deployed to {folder}", "");
                        Task.Delay(1500);
                        Notify("Menu Setup Successfully Use 'Insert' Button To Open it Anytime", "");
                    }
                }
                catch (Exception ex)
                {
                    Notify("Failed", $"Could not deploy to {folder}");
                }
            }
        }
    }
}
