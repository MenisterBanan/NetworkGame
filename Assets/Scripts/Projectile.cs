using UnityEngine;
using Unity.Netcode;
public class Projectile : NetworkBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.GetComponent<PlayerNetworkThings>().TakeDamage(1);
            Destroy(gameObject);
        }
        else
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Level"))
            {
                Destroy(gameObject);
            }
        }
    }
}
