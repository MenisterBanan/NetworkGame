using UnityEngine;
using Unity.Netcode;
using NUnit.Framework;
using System.Collections.Generic;

public class SpawnPointManager : MonoBehaviour
{
    [SerializeField] List<Transform> SpawnPos = new List<Transform>();
    [SerializeField] NetworkManager NetworkManager;
    int playersJoined;
    private void Awake()
    {
        NetworkManager.ConnectionApprovalCallback += OnConnoectionApproval;


    }

    void OnConnoectionApproval(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
    {
        response.Approved = true;
        response.CreatePlayerObject = true;
     
        response.Position = SpawnPos[playersJoined].position;
        playersJoined++;


    }

}
