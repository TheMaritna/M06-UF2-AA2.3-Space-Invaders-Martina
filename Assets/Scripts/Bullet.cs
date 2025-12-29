using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("info")]
    [SerializeField] public float speed;
    [SerializeField] public float destoyTime = 5f;

    private void Start()
    {
        Invoke("destroyObj", destoyTime);
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1 * speed * Time.deltaTime);
    }

    public void destroyObj()
    {
        Destroy(this.gameObject);
    }
}
