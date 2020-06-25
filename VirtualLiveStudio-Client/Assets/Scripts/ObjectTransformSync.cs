using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtualLiveStudio;
using VirtualLiveStudio.Shared.MessagePackObjects;

public class ObjectTransformSync : MonoBehaviour
{
    private ObjectTransformSyncHub objectTransformSyncHub = new ObjectTransformSyncHub();

    [SerializeField]
    private string UniqueID = Guid.NewGuid().ToString();

    private SyncObjectTransform lastSyncObjectTransform = null;

    private async void Start()
    {
        objectTransformSyncHub.Connect();
        objectTransformSyncHub.OnSendTransformEvent += ObjectTransformSyncHub_OnSendTransformEvent;
        await objectTransformSyncHub.RegisterAsync(UniqueID);
        lastSyncObjectTransform = new SyncObjectTransform(); //for wait Register
    }

    private async void Update()
    {
        if (lastSyncObjectTransform != null && (lastSyncObjectTransform.Position != transform.position || lastSyncObjectTransform.Rotation != transform.rotation))
        {
            lastSyncObjectTransform = new SyncObjectTransform { Name = UniqueID, Position = transform.position, Rotation = transform.rotation };
            await objectTransformSyncHub.SendTransformAsync(lastSyncObjectTransform);
        }
    }

    private void ObjectTransformSyncHub_OnSendTransformEvent(SyncObjectTransform syncObjectTransform)
    {
        if (syncObjectTransform == null) return; // first join user
        lastSyncObjectTransform = syncObjectTransform;
        transform.SetPositionAndRotation(syncObjectTransform.Position, syncObjectTransform.Rotation);
    }

    private async void OnDestroy() => await objectTransformSyncHub.DisposeAsync();

}
