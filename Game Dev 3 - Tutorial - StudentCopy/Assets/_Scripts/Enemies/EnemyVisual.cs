using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    SpriteRenderer spriteRenderer; // To render the enemy sprite
    public EnemyData enemyData; // Data for the enemy

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        spriteRenderer.sprite = enemyData.shipSprite; // Set the enemy sprite
    }
}