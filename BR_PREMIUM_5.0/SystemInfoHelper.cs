using System;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Windows.Forms;
using Guna.UI2.WinForms;

public class SystemInfoHelper
{
    private readonly Label pcNameLabel, hwidLabel, ipLabel, ramLabel, cpuLabel;
    //fpsLabel,
    private readonly Guna2CircleProgressBar ramBar, cpuBar;
    private readonly Timer updateTimer;
    private PerformanceCounter cpuCounter;
    private PerformanceCounter ramCounter;
    private float totalRam;

    public SystemInfoHelper(
        //Label fps,
        Label pcName, Label hwid, Label ip, Label ram, Label cpu,
        Guna2CircleProgressBar ramBar, Guna2CircleProgressBar cpuBar)
    {
        //fpsLabel = fps;
        pcNameLabel = pcName;
        hwidLabel = hwid;
        ipLabel = ip;
        ramLabel = ram;
        cpuLabel = cpu;
        this.ramBar = ramBar;
        this.cpuBar = cpuBar;

        cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        totalRam = GetTotalPhysicalMemoryInMB();

        updateTimer = new Timer { Interval = 5500 };
        updateTimer.Tick += UpdateSystemInfo;
    }

    public void Start()
    {
        updateTimer.Start();
    }

    private void UpdateSystemInfo(object sender, EventArgs e)
    {
        //fpsLabel.Text = $"{new Random().Next(25, 240)} FPS";
        pcNameLabel.Text = Environment.MachineName;
        hwidLabel.Text = GetHardwareId();
        ipLabel.Text = GetLocalIPAddress();

        float availableRam = ramCounter.NextValue();
        float usedRam = totalRam - availableRam;
        int ramUsage = (int)((usedRam / totalRam) * 100);
        ramLabel.Text = $"{ramUsage}%";
        ramBar.Value = ramUsage;
        ramBar.Text = $"{ramUsage}%";

        int cpuUsage = (int)cpuCounter.NextValue();
        cpuLabel.Text = $"{cpuUsage}%";
        cpuBar.Value = cpuUsage;
        cpuBar.Text = $"{cpuUsage}%";
    }

    private string GetHardwareId()
    {
        try
        {
            using (var searcher = new ManagementObjectSearcher("select ProcessorId from Win32_Processor"))
            {
                foreach (var obj in searcher.Get())
                {
                    return obj["ProcessorId"]?.ToString() ?? "Unknown";
                }
            }
        }
        catch
        {
            return "Unknown";
        }
        return "Unknown";
    }

    private string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return "Unknown";
    }

    private float GetTotalPhysicalMemoryInMB()
    {
        using (var searcher = new ManagementObjectSearcher("SELECT TotalPhysicalMemory FROM Win32_ComputerSystem"))
        {
            foreach (var obj in searcher.Get())
            {
                if (float.TryParse(obj["TotalPhysicalMemory"]?.ToString(), out var bytes))
                {
                    return bytes / (1024 * 1024);
                }
            }
        }
        return 0;
    }
}
