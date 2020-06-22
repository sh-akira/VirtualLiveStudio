using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace VirtualLiveStudio
{
    public class TestService : MonoBehaviour
    {
        public string Name = "TestName";
        public async Task<string> AskHello()
        {
            return await VirtualLiveStudioCore.TestService.AskHello(Name);
        }
    }
}