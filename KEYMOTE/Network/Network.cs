using System.Net;

using ICENet;
using ICENet.Traffic;

class Network
{
    private IceServer? _server;

    public bool Available { get { try { return _server!.Connections[0].IsConnected; } catch { return false; } } }

    public int Ping
    {
        get
        {
            try
            {
                return _server!.Connections[0].Ping;
            }
            catch
            {
                return 0;
            }
        }
    }

    public static Network Instance
    {

        get
        {
            return _instance!;
        }
    }

    private static Network? _instance;

    public Network(int port)
    {
        _instance = this;
        _server = new IceServer(null!, 1);
        _server.TryStart(new IPEndPoint(IPAddress.Any, port));
    }

    public void AddHandler<T>(Action<T> action) where T : Packet, new() => _server!.Traffic.AddOrUpdateHandler<T>((p, c) => action(p));

    public void TrySend(Packet packet) { try { _server!.Connections[0]?.Send(packet); } catch { } }
}
