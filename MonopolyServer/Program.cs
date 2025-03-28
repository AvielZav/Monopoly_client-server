﻿using System;
using System.Threading.Tasks;

namespace MonopolyServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const int port = 5000;
            GameServer server = new GameServer(port);

            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                Console.WriteLine("Shutting down server...");
                server.Stop();
                eventArgs.Cancel = true;
            };

            AppDomain.CurrentDomain.ProcessExit += (sender, eventArgs) =>
            {
                Console.WriteLine("Server exiting...");
                server.Stop();
            };

            await server.StartAsync();
        }
    }
}