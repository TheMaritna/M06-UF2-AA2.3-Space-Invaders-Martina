using UnityEngine;

public class Disaparicion : MonoBehaviour
{
    public float time = 1f;
    private AudioSource deadSound;

    private void Start()
    {
        deadSound = GetComponent<AudioSource>();
        Invoke("DestroyMe", time);
    }
    public void DestroyMe()
    {
        deadSound.Play();
        Destroy(this.gameObject);
        
    }
}
