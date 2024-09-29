using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    //Default life value
    public EnemyData enemyData;
    //Reference to the player firing script
    private PlayerFiring firingScriptRef;
    //Ref to the enemy vfx script
    private EnemyVfx enemyVfx;

    private void Start()
    {
        //Gets the data
        firingScriptRef = FindObjectOfType<PlayerFiring>();        
        enemyVfx = GetComponent<EnemyVfx>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //Will flash
            StartCoroutine(enemyVfx.HitFlash());
            //Will destroy the bullet
            Destroy(collision.gameObject);
            //Will remove life based on the current damage thre player can do
            RemoveHp(firingScriptRef.damageValue);
        }
    }

    public void RemoveHp(int hpToRemove)
    {
        //Destroys the enemyShip if the hit brings it tp 0 or below
        if ((enemyData.shipHp - hpToRemove) <= 0)
        {
            //You can add a timer to it by putting a comma and a float variable Example:Destroy(gameObject, 0.5f)
            Destroy(gameObject);
        }
        else
        {
            //Removes the required hp
            enemyData.shipHp -= hpToRemove;
        }
    }


}
