/*
this.Alert("Sniper Scope : Applying!", FXMSG.enmType.Applying);
 Console.Beep(400, 600);
 FastMem memoryfast = new FastMem();
 string[] processNames = new string[1] { "HD-Player" };
 if (!memoryfast.SetProcess(processNames))
 {
     memoryfast = (FastMem)null;
 }
 else
 {
     foreach (long address in await memoryfast.AoBScan("FF FF FF FF 08 00 00 00 00 00 60 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01"))
         memoryfast.AobReplace(address, "FF FF FF FF 08 00 00 00 00 00 60 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 FF FF 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01");

     this.Alert("Sniper Scope : Applied!!", FXMSG.enmType.Applied);

     Console.Beep(400, 300);
     memoryfast = (FastMem)null;
*/