using System;
using PREMIUM_6._0;
using DiscordRPC;
using KeyAuth;
using PREMIUM_6._0.Views;

public class RichStatus
{
    public static DiscordRpcClient client;
    public static Timestamps rpctimestamp { get; set; }
    private static RichPresence presence;

    public static void InitializeRPC()
    {
        client = new DiscordRpcClient("1350087937236406292");
        client.Initialize();

        DiscordRPC.Button[] buttons = {
                new DiscordRPC.Button() { Label = "Website", Url = "https://bruuuhcheats.xyz" }
            };

        presence = new RichPresence()
        {
            Buttons = buttons,
            Timestamps = rpctimestamp,

            Assets = new Assets()
            {
                //LargeImageKey = "",
                LargeImageKey = "https://i.giphy.com/media/v1.Y2lkPTc5MGI3NjExNTBucnM5MDI1aWNiaHU3Z2F4MWJpcHIwMmNjb3I5bTNjdGhlamMyciZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/KLLCeBZIqApC1jg22R/giphy.gif",
                LargeImageText = "BRUUUH CHEATS",
                SmallImageKey = "https://media4.giphy.com/media/xmOMPI63SsyZyKz2Tx/giphy.gif?cid=790b7611485d6e9b471bcd8f93609e96f8a02c35a7e05685&rid=giphy.gif&ct=s",
                SmallImageText = "Tested & Trusted"
            }
        };

        client.SetPresence(presence);
        UpdateDiscordPresence();
    }

    public static void SetState(string state, bool watching = false)
    {
        if (watching)
            state = "Looking at " + state;

        presence.State = state;
        client.SetPresence(presence);
    }

    private static void UpdateDiscordPresence()
    {
        if (Login.KeyAuthApp.user_data != null)
        {
            string username = Login.KeyAuthApp.user_data.username;
            DateTime expiryDateTime = UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.subscriptions[0].expiry));

            presence.Details = $"User: {username}";
            presence.State = $"Expiry Date: {expiryDateTime:yyyy/MM/dd HH:mm}";
        }
        else
        {
            presence.Details = "Version 6.9.6";
            presence.State =  "Developed By Gefrezim";
        }

        client.SetPresence(presence);
    }

    private static DateTime UnixTimeToDateTime(long unixTime)
    {
        DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return unixStart.AddSeconds(unixTime).ToLocalTime();
    }

    public static void DisconnectRPC()
    {
        if (client != null)
        {
            client.ClearPresence();
            client.Dispose();
            client = null;
        }
    }
}