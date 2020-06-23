using Grpc.Core;
using MagicOnion.Client;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtualLiveStudio.Shared.Services;

namespace VirtualLiveStudio
{

    public class VirtualLiveStudioCore : MonoBehaviour
    {
        [SerializeField]
        private string connectionTarget = "localhost";

        [SerializeField]
        private int connectionPort = 20201;


        private Channel grpcChannel;

        public static ITestService TestService;

        private void Awake()
        {
            grpcChannel = new Channel(connectionTarget, connectionPort, ChannelCredentials.Insecure);

            TestService = MagicOnionClient.Create<ITestService>(grpcChannel);
        }

        private async void OnDestroy()
        {
            await grpcChannel.ShutdownAsync();
        }
    }
}