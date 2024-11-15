using UnityEngine;


[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public Sprite shipSprite; // Sprite for the enemy ship
    public float shipSpeed; // Speed of the enemy ship
    public int shipHp; // Health points of the enemy ship
}
