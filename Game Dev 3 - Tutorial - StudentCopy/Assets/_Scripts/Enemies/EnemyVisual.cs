using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] EnemyData enemyData;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = enemyData.shipSprite;
    }

}