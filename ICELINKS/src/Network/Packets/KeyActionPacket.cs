using ICENet.Core.Data;
using ICENet.Traffic;

using WindowsInput.Native;

public class KeyActionPacket : Packet
{
    public override int Id => 95;

    public override bool IsReliable => false;

    public VirtualKeyCode KeyName;

    public bool KeyPressed;

    private static Dictionary<string, VirtualKeyCode> _keyProviders = new Dictionary<string, VirtualKeyCode>()
    {
    { "esc", VirtualKeyCode.ESCAPE },
    { "f1", VirtualKeyCode.F1 },
    { "f2", VirtualKeyCode.F2 },
    { "f3", VirtualKeyCode.F3 },
    { "f4", VirtualKeyCode.F4 },
    { "f5", VirtualKeyCode.F5 },
    { "f6", VirtualKeyCode.F6 },
    { "f7", VirtualKeyCode.F7 },
    { "f8", VirtualKeyCode.F8 },
    { "f9", VirtualKeyCode.F9 },
    { "f10", VirtualKeyCode.F10 },
    { "f11", VirtualKeyCode.F11 },
    { "f12", VirtualKeyCode.F12 },
    { "prtscreen", VirtualKeyCode.PRINT },
    { "scrolllock", VirtualKeyCode.SCROLL },
    { "pause", VirtualKeyCode.PAUSE },
    { "tilda", VirtualKeyCode.OEM_3 },
    { "1", VirtualKeyCode.VK_1 },
    { "2", VirtualKeyCode.VK_2 },
    { "3", VirtualKeyCode.VK_3 },
    { "4", VirtualKeyCode.VK_4 },
    { "5", VirtualKeyCode.VK_5 },
    { "6", VirtualKeyCode.VK_6 },
    { "7", VirtualKeyCode.VK_7 },
    { "8", VirtualKeyCode.VK_8 },
    { "9", VirtualKeyCode.VK_9 },
    { "0", VirtualKeyCode.VK_0 },
    { "-", VirtualKeyCode.OEM_MINUS },
    { "=", VirtualKeyCode.OEM_PLUS },
    { "backspace", VirtualKeyCode.BACK },
    { "tab", VirtualKeyCode.TAB },
    { "q", VirtualKeyCode.VK_Q },
    { "w", VirtualKeyCode.VK_W },
    { "e", VirtualKeyCode.VK_E },
    { "r", VirtualKeyCode.VK_R },
    { "t", VirtualKeyCode.VK_T },
    { "y", VirtualKeyCode.VK_Y },
    { "u", VirtualKeyCode.VK_U },
    { "i", VirtualKeyCode.VK_I },
    { "o", VirtualKeyCode.VK_O },
    { "p", VirtualKeyCode.VK_P },
    { "[", VirtualKeyCode.OEM_4 },
    { "]", VirtualKeyCode.OEM_6 },
    { "caps", VirtualKeyCode.CAPITAL },
    { "a", VirtualKeyCode.VK_A },
    { "s", VirtualKeyCode.VK_S },
    { "d", VirtualKeyCode.VK_D },
    { "f", VirtualKeyCode.VK_F },
    { "g", VirtualKeyCode.VK_G },
    { "h", VirtualKeyCode.VK_H },
    { "j", VirtualKeyCode.VK_J },
    { "k", VirtualKeyCode.VK_K },
    { "l", VirtualKeyCode.VK_L },
    { "semicolon", VirtualKeyCode.OEM_1 },
    { "paws", VirtualKeyCode.PAUSE },
    { "backslash", VirtualKeyCode.OEM_5 },
    { "enter", VirtualKeyCode.RETURN },
    { "lshift", VirtualKeyCode.LSHIFT },
    { "z", VirtualKeyCode.VK_Z },
    { "x", VirtualKeyCode.VK_X },
    { "c", VirtualKeyCode.VK_C },
    { "v", VirtualKeyCode.VK_V },
    { "b", VirtualKeyCode.VK_B },
    { "n", VirtualKeyCode.VK_N },
    { "m", VirtualKeyCode.VK_M },
    { "less", VirtualKeyCode.OEM_COMMA },
    { "greater", VirtualKeyCode.OEM_PERIOD },
    { "slash", VirtualKeyCode.OEM_2 },
    { "rshift", VirtualKeyCode.RSHIFT },
    { "lctrl", VirtualKeyCode.LCONTROL },
    { "lwin", VirtualKeyCode.LWIN },
    { "lalt", VirtualKeyCode.LMENU },
    { "space", VirtualKeyCode.SPACE },
    { "ralt", VirtualKeyCode.RMENU },
    { "rwin", VirtualKeyCode.RWIN },
    { "application", VirtualKeyCode.APPS },
    { "rctrl", VirtualKeyCode.RCONTROL },
    { "insert", VirtualKeyCode.INSERT },
    { "home", VirtualKeyCode.HOME },
    { "pageup", VirtualKeyCode.PRIOR },
    { "delete", VirtualKeyCode.DELETE },
    { "end", VirtualKeyCode.END },
    { "pagedown", VirtualKeyCode.NEXT },
    { "left", VirtualKeyCode.LEFT },
    { "down", VirtualKeyCode.DOWN },
    { "right", VirtualKeyCode.RIGHT },
    { "up", VirtualKeyCode.UP }
    };

    protected override void Read(ref Data data)
    {
        var sourceKey = data.ReadString();
        KeyPressed = data.ReadBoolean();

        _keyProviders.TryGetValue(sourceKey, out KeyName);
    }
}