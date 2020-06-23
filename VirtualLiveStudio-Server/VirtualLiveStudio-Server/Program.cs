using Grpc.Core;
using MagicOnion.Hosting;
using MagicOnion.Server;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace VirtualLiveStudio
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await MagicOnionHost.CreateDefaultBuilder()
                .UseMagicOnion(
                   new ServerPort("localhost", 20201, ServerCredentials.Insecure)
                )
                .RunConsoleAsync();
        }
    }
}
