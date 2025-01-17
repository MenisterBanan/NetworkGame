
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class ClientPlayerMove : NetworkBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerInput playerInput;

    private void Awake()
    {
        playerMovement.enabled = false;
        playerInput.enabled = false;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        enabled = IsClient;

        if (!IsOwner)
        {
            enabled = false;
            playerMovement.enabled = false;
            playerInput.enabled = false;
            return;
        }

        // Our stuff after this

        playerMovement.enabled = true;
        playerInput.enabled = true;

    }

}
