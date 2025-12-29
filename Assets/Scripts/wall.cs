using UnityEngine;
using System.Collections.Generic;

public class wall : MonoBehaviour
{
    [SerializeField] private List<Sprite> damageSprites = new List<Sprite>();
    [SerializeField] private float colliderShrinkAmount = 0.1f;

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (damageSprites.Count > 0) spriteRenderer.sprite = damageSprites[0];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet") || other.CompareTag("enemyBullet"))
        {
            Destroy(other.gameObject);

            currentSpriteIndex++;

            if (currentSpriteIndex < damageSprites.Count)
            {
                spriteRenderer.sprite = damageSprites[currentSpriteIndex];
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
    }

}
