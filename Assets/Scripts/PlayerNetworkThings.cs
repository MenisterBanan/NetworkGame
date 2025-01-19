using UnityEngine;
using Unity.Netcode;
using UnityEngine.Events;

public class PlayerNetworkThings : NetworkBehaviour
{
    private NetworkVariable<int> playerHealth = new(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
    public UnityAction<int> OnHealthChanged;
    [SerializeField] Transform Spawn1;
    [SerializeField] Transform Spawn2;

    //public override void OnNetworkSpawn()
    //{
    //    base.OnNetworkSpawn();

    //    playerHealth.OnValueChanged += OnHealthValueChanged;

    //}

    //public override void OnNetworkDespawn()
    //{
    //    base.OnNetworkDespawn();

    //    playerHealth.OnValueChanged -= OnHealthValueChanged;
    //}
    
    //private void OnHealthValueChanged(int oldValue, int newValue)
    //{
    //    OnHealthChanged?.Invoke(newValue);

    //}

    private void Update()
    {
        PlayerDeath();
    }

    public void TakeDamage(int damage)
    {
        playerHealth.Value -= damage;

    }

    void PlayerDeath()
    {
        if (playerHealth.Value <= 0)
        {
          gameObject.SetActive(false);
        }
    }

}
