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
                .UseMagicOnion()
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<MagicOnionHostingOptions>(options =>
                    {
                        options.ServerPorts = new[] { 
                            new MagicOnionHostingServerPortOptions { 
                                Host = "localhost", 
                                Port = 20201, 
                                UseInsecureConnection = true 
                            }
                        };
                    });
                })
                .RunConsoleAsync();
        }
    }
}
