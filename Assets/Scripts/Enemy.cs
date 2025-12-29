using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Type")]
    public int EnemyType = 0;

    [Header("References")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;
    private GameManager gameManager;
    public GameObject deadParticle;


    private float nextShootTime;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        switch (EnemyType)
        {
            case 0:
                basicEnemy();
                break;
            case 1:
                mediumEnemy();
                break;
            case 2:
                break;
        }
    }

    private void basicEnemy()
    {
        // comportamiento b�sico (ej. moverse o patrullar)
    }

    private void mediumEnemy()
    {
        // comportamiento intermedio (ej. seguir al jugador)
    }
    public void Shoot()
    {
        GameObject actualBullet = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        Rigidbody2D rb = actualBullet.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = shotPoint.right * 5f; // ajusta la velocidad del disparo
    }

    private void pointsSystem(int type)
    {
        if (gameManager == null)
            return;
        switch (type)
        {
            case 0:
                gameManager.score += 10;
                break;
            case 1:
                gameManager.score += 20;
                break;
            case 2:
                gameManager.score += 30;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            pointsSystem(EnemyType);
            Destroy(gameObject);
            collision.GetComponent<Bullet>()?.destroyObj();
            GameObject Particle = Instantiate(deadParticle);
            Particle.transform.position = transform.position;
        }
    }

}
