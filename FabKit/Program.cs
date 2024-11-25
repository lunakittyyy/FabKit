namespace FabKit
{
    internal class Program
    {
        public static Server? serverInstance;
        static void Main(string[] args)
        {
            serverInstance = new Server();
            serverInstance.StartServer();
        }
    }
}
