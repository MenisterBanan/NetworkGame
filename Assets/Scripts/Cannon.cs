using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] Projectile BulletPrefab;
    [SerializeField] GameObject BulletSpawnPos;
    [SerializeField] float attackSpeed;
    [SerializeField] float bulletSpeed;
    float attackTimer = 0;
    void Start()
    {

    }


    void Update()
    {
        ShootBullet();
    }

    void ShootBullet()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 arrowDirection = mousePos - (Vector2)transform.position;
        arrowDirection.Normalize();

        if (Time.time > attackTimer && Input.GetKeyDown(KeyCode.Space))
        {
            attackTimer = Time.time + attackSpeed;

            Projectile arrow = Instantiate(BulletPrefab, transform.position + transform.right * 0.8f, Quaternion.identity, BulletSpawnPos.transform);

            arrowDirection = transform.right;
            arrow.transform.right = arrowDirection;
            arrow.GetComponent<Rigidbody2D>().linearVelocity = arrowDirection * bulletSpeed;

        }
    }


}
