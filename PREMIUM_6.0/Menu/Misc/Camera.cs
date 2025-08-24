using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bruuuh;
using MemoryAim2;
using PREMIUM_6._0.Views;

namespace PREMIUM_6._0.Menu.Misc
{
    public class Camera
    {
        private Home _mainForm;
        Bool Bool = new Bool();
        Evelyn bruuuh = new Evelyn();
        AobMem2 memoryfast = new AobMem2();
        public Camera(Home mainForm)
        {
            _mainForm = mainForm;

        }
        private void Notify(string message, string message1)
        {
            _mainForm.Invoke(new Action(() =>
            {
                _mainForm.Notify(message, message1);
            }));
        }



        string leftSearch = "00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 80 7f 00 00 80 7f 00 00 80 7f 00 00 80 ff";
        string leftReplace = "00 00 00 00 22 9e 93 40 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 80 7f 00 00 80 7f 00 00 80 7f 00 00 80 ff";
        string upSearch = "00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 80 7f 00 00 80 7f 00 00 80 7f 00 00 80 ff";
        string upReplace = "00 00 00 00 22 9e 93 40 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 80 bf 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3f 00 00 00 00 00 00 00 00 00 00 80 bf 00 00 80 7f 00 00 80 7f 00 00 80 7f 00 00 80 ff";
        private List<long> CameraLeft1Address = new List<long>();
        private List<long> CameraLeft2Address = new List<long>();
        private List<long> CameraRight1Address = new List<long>();
        private List<long> CameraRight2Address = new List<long>();
        private List<long> CameraUp1Address = new List<long>();
        private List<long> CameraUp2Address = new List<long>();
        bool k = false;

        public void EnableCameraHack()
        {
            if (Bool.OthersMem == 0)
            {
                DetermineInjection1();
            }
            else if (Bool.OthersMem > 1)
            {
                DetermineInjection2();
            }
        }
        private void DetermineInjection1()
        {
            if (Bool.CameraPostion == 0)
            {
                LoadCameraLeft1();
            }
            else if (Bool.CameraPostion == 1)
            {
                CameraLeft1();
            }
            else if (Bool.CameraPostion == 2)
            {

            }
        }
        private void DetermineInjection2()
        {
            if (Bool.CameraPostion == 0)
            {
                LoadCameraLeft2();
            }
            else if (Bool.CameraPostion == 1)
            {
                CameraLeft2();
            }
            else if (Bool.CameraPostion == 2)
            {

            }
        }


        #region CAMERA LEFT
        private async Task LoadCameraLeft1()
        {
            Notify("Loading Camera Left [0]", "");

            string[] processName = { "HD-Player" };
            bool success = memoryfast.SetProcess(processName);

            if (!success)
            {
                Notify("Open Emulator", "2000");
                return;
            }

            IEnumerable<long> result = await memoryfast.AoBScan(leftSearch);

            CameraLeft1Address = result.ToList();

            if (CameraLeft1Address.Count > 0)
            {
                Notify("Camera Left Loaded [0]", "400");
                Bool.isCameraLeft1Loaded = true;
            }
            else
            {
                Notify("No Address Found [0]", "2000");
                return;
            }
        }

        public void CameraLeft1()
        {
            if (Bool.isCameraLeft1Loaded == false)
            {
                LoadCameraLeft1();
            }
            else if (Bool.isCameraLeft1Enabled == true)
            {
                OffCameraLeft1();
            }
            else if (Bool.isCameraLeft1Enabled == false)
            {
                OnCameraLeft1();
            }
        }
        public void OnCameraLeft1()
        {
            foreach (long address in CameraLeft1Address)
            {
                memoryfast.AobReplace(address, leftReplace);
            }

            Notify("Enabled Camera Left", "400");
            Bool.isCameraLeft1Enabled = true;
        }
        
        public void OffCameraLeft1()
        {
            foreach (long address in CameraLeft1Address)
            {
                memoryfast.AobReplace(address, leftSearch);
            }

            Notify("Disabled Camera Left", "400");
            Bool.isCameraLeft1Enabled = false;
        }



        private async Task LoadCameraLeft2()
        {
            string search = leftSearch;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Notify("Emulator Isnt Running", "800");
                return;
            }

            bruuuh.OpenProcess("HD-Player");
            Notify("Loading Camera Up [1]", "");

            IEnumerable<long> foundAddresses = await bruuuh.AoBScan(search, writable: true);

            if (foundAddresses.Count() > 0)
            {
                CameraLeft2Address = foundAddresses.ToList();
                Notify("Loaded Camera Left [1]", "400");
                Bool.isCameraLeft2Loaded = true;
            }
            else
            {
                Notify("Failed to Load Camera Left [1]", "2000");
                return;
            }
        }
        public void CameraLeft2()
        {
            if (Bool.isCameraLeft2Loaded == false)
            {
                LoadCameraLeft2();
            }
            if (Bool.isCameraLeft2Enabled == false)
            {
                OnCameraLeft2();
            }
            else if (Bool.isCameraLeft2Enabled == true)
            {
                OffCameraLeft2();
            }
        }
        private void OnCameraLeft2()
        {
            string replace = leftReplace;
            string search = leftSearch;
            if (CameraLeft2Address.Count > 0)
            {
                bool success = false;

                foreach (var address in CameraLeft2Address)
                {
                    int delay = Bool.CameraDelay * 1000;

                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = delay;
                    timer.Tick += (s, args) =>
                    {
                        timer.Stop();
                        timer.Dispose();
                        bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                        if (writeResult)
                        {
                            success = true;
                        }
                    };
                    timer.Start();
                }

                if (success)
                {
                    Notify("Enabled Camera Left [1]", "400");
                    Bool.isCameraLeft2Enabled = true;
                }
                else
                {
                    Notify("Camera Left Failed [1]", "800");
                    Bool.isCameraLeft2Enabled = false;
                }
            }
            else
            {
                Notify("Camera Down Isnt Loaded [1]", "800");
            }

        }
        private void OffCameraLeft2()
        {
            string replace = leftSearch;
            if (CameraLeft2Address.Count > 0)
            {
                bool success = false;

                foreach (var address in CameraLeft2Address)
                {
                    int delay = Bool.CameraDelay * 1000;

                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                    timer.Interval = delay;
                    timer.Tick += (s, args) =>
                    {
                        timer.Stop();
                        timer.Dispose();
                        bool writeResult = bruuuh.WriteMemory(address.ToString("X"), "bytes", replace);
                        if (writeResult)
                        {
                            success = true;
                        }
                    };
                    timer.Start();
                }

                if (success)
                {
                    Notify("Disabled Camera Left [1]", "400");
                    Bool.isCameraLeft2Enabled = true;
                }
                else
                {
                    Notify("Camera Left Failed [1]", "800");
                }
            }
            else
            {
                Notify("Camera Left Isnt Loaded [1]", "800");
            }

        }

        #endregion
        
        







    }
}

