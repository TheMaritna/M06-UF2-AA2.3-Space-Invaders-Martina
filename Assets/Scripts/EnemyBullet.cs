using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("info")]
    [SerializeField] public float speed;
    [SerializeField] public float destoyTime = 5f;

    public GameObject deadParticle;

    private void Start()
    {
        Invoke("destroyObj", destoyTime);
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 1 * speed * Time.deltaTime);
    }

    public void destroyObj()
    {
        Destroy(this.gameObject);
    }
}
