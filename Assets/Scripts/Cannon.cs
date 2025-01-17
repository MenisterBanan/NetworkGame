using UnityEngine;
using Unity.Netcode;

public class Cannon : NetworkBehaviour
{
    [SerializeField] Projectile BulletPrefab;

    [SerializeField] float attackSpeed;
    [SerializeField] float bulletSpeed;
    float attackTimer = 0;

    void Update()
    {
        ShootBullet();
    }

    void ShootBullet()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 arrowDirection = mousePos - (Vector2)transform.position;
        arrowDirection.Normalize();

        if (Time.time > attackTimer && Input.GetKeyDown(KeyCode.Space) && IsOwner)
        {
            attackTimer = Time.time + attackSpeed;
            ShootServerRpc(arrowDirection);
        }
    }

    [ServerRpc]
    void ShootServerRpc(Vector2 arrowDirection)
    {

        Projectile arrow = Instantiate(BulletPrefab, transform.position + transform.right * 1.2f, Quaternion.identity);

        arrowDirection = transform.right;
        arrow.transform.right = arrowDirection;
        arrow.GetComponent<Rigidbody2D>().linearVelocity = arrowDirection * bulletSpeed;

        arrow.NetworkObject.Spawn();
    }


}
