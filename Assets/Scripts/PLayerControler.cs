using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayerControler : MonoBehaviour
{
    [Header("info")]
    [SerializeField] public float speed;
    [SerializeField] public float lifes = 3;

    [Header("reference")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shotPoint;
    private AudioSource shotSound;

    private void Start()
    {
        shotSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector2 direciton = new Vector2(Input.GetAxisRaw("Horizontal"), 0 );
        transform.position = new Vector3(transform.position.x + direciton.x  * speed * Time.deltaTime, transform.position.y, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject actualbullet = Instantiate(bullet);
            actualbullet.transform.position = shotPoint.position;
            shotSound.Play();
        }
    }
    private void Die()
    {
        if(lifes <= 0)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            lifes -= 1;
            transform.position = new Vector3(0, -6, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemyBullet")
        {
            Die();
        }
        if(collision.tag == "EnemyGrup")
        {
            SceneManager.LoadScene(0);
        }
    }
}
