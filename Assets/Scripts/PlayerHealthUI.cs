using TMPro;
using Unity.Netcode;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    PlayerNetworkThings playerNetworkThings;
    [SerializeField] TextMeshProUGUI playerHealthText;
    void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;
    } 
    void OnDestroy()
    {
        NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback -= OnClientDisconnected;
    }

    void OnClientConnected(ulong _)
    {
        playerNetworkThings.OnHealthChanged += OnPlayerHealthChanged;
    }    
    void OnClientDisconnected(ulong _)
    {
        playerNetworkThings.OnHealthChanged -= OnPlayerHealthChanged;
    }

    void OnPlayerHealthChanged(int newHealthValue)
    {
        playerHealthText.text = "Healt" + newHealthValue;

    }
}
