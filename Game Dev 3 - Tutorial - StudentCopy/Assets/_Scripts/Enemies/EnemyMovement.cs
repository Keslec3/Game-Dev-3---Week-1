using UnityEngine;

public class EnemyMovement : MonoBehaviour
{    
    public EnemyData enemyData;

    private void FixedUpdate()
    {
        //Does not execute the rest of the code if this check is true
        if (GameManager.isGameOn == false)  return;
        //To move the ship
        Movement();
    }


    void Movement()
    {
        //To store the position before the movement
        Vector2 pos = transform.position;
        //To move the ship down
        pos.y -= enemyData.shipSpeed * Time.fixedDeltaTime;
        //To actually move the ship
        transform.position = pos;
    }
}
