using Microsoft.IdentityModel.Logging;

public class Bool
{
    #region Aimbot

    public bool AimbotHead { get; set; } = false;
    public bool AimbotLegit { get; set; } = false;
    public bool AimbotAI { get; set; } = false;

    public bool AimbotDrag { get; set; } = false;
    public bool AimbotNeck { get; set; } = false;

    public bool NoRecoil { get; set; } = false;

    public bool ScopeTrack2x { get; set; } = false;
    public bool AimFov { get; set; } = false;

    #endregion

    #region Sniper

    public bool SniperScope { get; set; } = false;
    public bool SniperSwitch { get; set; } = false;
    public bool AWMSwitch { get; set; } = false;
    public bool AWMYSwitch { get; set; } = false;
    public bool AWMScope { get; set; } = false;
    public bool M82BSwitch { get; set; } = false;
    public bool M24Switch { get; set; } = false;

    public bool SniperTracking { get; set; } = false;
    public bool SniperAim { get; set; } = false;
    public bool SniperFov { get; set; } = false;
    public bool SniperDelayFix { get; set; } = false;

    #endregion

    #region Visuals
    public bool isChamsMenuReady { get; set; } = false;
    public int ChamsMenu { get; set; } = 0;
    public int HEmulator { get; set; } = 0;

    #endregion


    #region Misc
    public static int CameraPostion { get; set; } = 0;

    public bool isCameraLeft1Loaded { get; set; } = false;
    public bool isCameraLeft2Loaded { get; set; } = false;
    public bool isCameraRight1Loaded { get; set; } = false;
    public bool isCameraRight2Loaded { get; set; } = false;
    public bool isCameraUp1Loaded { get; set; } = false;
    public bool isCameraUp2Loaded { get; set; } = false;
    
    public bool isCameraLeft1Enabled { get; set; } = false;
    public bool isCameraLeft2Enabled { get; set; } = false;
    public bool isCameraRight1Enabled { get; set; } = false;
    public bool isCameraRight2Enabled { get; set; } = false;
    public bool isCameraUp1Enabled { get; set; } = false;
    public bool isCameraUp2Enabled { get; set; } = false;
    public bool isGlitchFireEnabled { get; set; } = false;
    public bool isGlitchFireLoaded { get; set; } = false;
    public bool isWallBypassed { get; set; } = false;
    public bool isWallHack1Loaded { get; set; } = false;
    public bool isWallHack1Enabled { get; set; } = false;
    public bool isWallOn { get; set; } = false;
    public bool isWallHack2Enabled { get; set; } = false;
    
    public bool isSpeedLoaded { get; set; } = false;
    public bool isSpeedTimerEnabled { get; set; } = false;

    public bool isFakelagManualenabled { get; set; } = false;
    public bool isFakelagAutoenabled { get; set; } = false;


    #endregion

    #region Settings

    public bool CanNotify { get; set; } = true;
    public bool is64Bit { get; set; } = false;
    public bool Strictdnd { get; set; } = false;

    public bool rpc { get; set; } = true;

    public static int GunSwitch { get; set; } = 0;
    public static int WallType { get; set; } = 0;

    public static int AimbotMem { get; set; } = 0;
    public static int OthersMem { get; set; } = 0;
    public static string AimbotAIMode { get; set; } = "NORMAL";

    public static int AimbotDelay { get; set; } = 1;
    public static int SpeedDelay { get; set; } = 1;
    public static int FakeLag { get; set; } = 1;
    public static int WallDelay { get; set; } = 1;
    public static int CameraDelay { get; set; } = 1;

    #endregion
}