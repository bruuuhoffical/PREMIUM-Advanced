using System;

namespace PREMIUM_6._0.Libaries
{
    public class Additional
    {
        public void exit()
        {
            Environment.Exit(0);
        }
        public void Restart()
        {
            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
            Environment.Exit(0);
        }
        public void discord()
        {
            System.Diagnostics.Process.Start("https://discord.com/users/1200223126689161247");
        }
        public void whatsapp()
        {
            System.Diagnostics.Process.Start("https://wa.link/1vzvok");
        }
    }
}
