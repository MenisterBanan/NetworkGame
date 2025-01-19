using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class MultiplayerStartThingy : MonoBehaviour
{
    [SerializeField] Button hostButton, joinButton;

    private void Awake()
    {
        AssignInputs();
    }

    void AssignInputs()
    {
        hostButton.onClick.AddListener( delegate { NetworkManager.Singleton.StartHost(); } );
        joinButton.onClick.AddListener( delegate { NetworkManager.Singleton.StartClient(); } );
    }

}
