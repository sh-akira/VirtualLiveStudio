using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtualLiveStudio;

public class Tester : MonoBehaviour
{
    [SerializeField]
    private TestService testService;

    private void OnGUI()
    {
        if (GUILayout.Button("AskHello"))
        {
            askHello();
        }
    }

    private async void askHello()
    {
        var received = await testService.AskHello();
        Debug.Log(received);
    }
}
