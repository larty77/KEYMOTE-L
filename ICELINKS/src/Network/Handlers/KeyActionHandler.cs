
using WindowsInput;

public class KeyActionHandler
{
    private readonly InputSimulator _inputSimulator;

    public KeyActionHandler()
    {
        Network.Instance.AddHandler<KeyActionPacket>(Handle);
        _inputSimulator = new InputSimulator();
    }

    private void Handle(KeyActionPacket packet) 
    {
        if (packet.KeyName is 0) { return; }

        if (packet.KeyPressed is true) { _inputSimulator.Keyboard.KeyDown(packet.KeyName); }
        if (packet.KeyPressed is false) { _inputSimulator.Keyboard.KeyUp(packet.KeyName); }

        Console.WriteLine(packet.KeyPressed ? $"{packet.KeyName} is pressed!" : $"{packet.KeyName} is upped!" + $"\t//Ping: {Network.Instance.Ping}ms!");
    }
}

