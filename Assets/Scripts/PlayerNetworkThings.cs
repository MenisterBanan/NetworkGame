using UnityEngine;
using Unity.Netcode;
using UnityEngine.Events;

public class PlayerNetworkThings : NetworkBehaviour
{
    private NetworkVariable<int> playerHealth = new(3, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    public UnityAction<int> OnHealthChanged;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        playerHealth.OnValueChanged += OnHealthValueChanged;
    }

    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();

        playerHealth.OnValueChanged -= OnHealthValueChanged;
    }
    
    private void OnHealthValueChanged(int oldValue, int newValue)
    {
        OnHealthChanged?.Invoke(newValue);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(IsOwner)
            {
                playerHealth.Value -= 1;
            }
        }
    }

}
