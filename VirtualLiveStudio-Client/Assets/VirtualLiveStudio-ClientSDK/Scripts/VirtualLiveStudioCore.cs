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


        public static Channel GrpcChannel;

        public static ITestService TestService;

        private void Awake()
        {
            if (GrpcChannel == null)
            {
                GrpcChannel = new Channel(connectionTarget, connectionPort, ChannelCredentials.Insecure);

                TestService = MagicOnionClient.Create<ITestService>(GrpcChannel);
            }
        }

        private async void OnDestroy()
        {
            await GrpcChannel.ShutdownAsync();
            GrpcChannel = null;
        }
    }
}