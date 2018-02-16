using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public Transform Enemy1DeathTrans;
    public Transform Enemy2DeathTrans;
    public Transform Enemy3DeathTrans;
    public Transform Enemy4DeathTrans;

    [System.Serializable]
    public class EnemyStats
    {
        public int HP = 2;
        public int dmg = 1;
    }

    public EnemyStats enemyStats = new EnemyStats();

    public void DamageEnemy(int amountOfDamage, string bulletTag)
    {
        //Debug.Log("I damage the enemy");
        enemyStats.HP -= amountOfDamage;


        if (enemyStats.HP <= 0)
        {

            switch (this.gameObject.tag)
            {
                case ("Enemy1"):
                    {
                        SpecialEffectsHelper1.Instance1.Explosion(transform.position, bulletTag);
                        Instantiate(Enemy1DeathTrans, transform.position, transform.rotation);
                        break;
                    }
                case ("Enemy2"):
                    {
                        SpecialEffectsHelper2.Instance2.Explosion(transform.position, bulletTag);
                        Instantiate(Enemy2DeathTrans, transform.position, transform.rotation);
                        break;
                    }
                case ("Enemy3"):
                    {
                        SpecialEffectsHelper3.Instance3.Explosion(transform.position, bulletTag);
                        Instantiate(Enemy3DeathTrans, transform.position, transform.rotation);
                        break;
                    }
                case ("Enemy4"):
                    {
                        SpecialEffectsHelper4.Instance4.Explosion(transform.position, bulletTag);
                        Instantiate(Enemy4DeathTrans, transform.position, transform.rotation);
                        break;
                    }
                case ("Enemy5"):
                    {
                        SpecialEffectsHelper5.Instance5.Explosion(transform.position, bulletTag);
                        break;
                    }
            }

            
            GameMaster.KillEnemy(this);
        }
    }

    // Collide something
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player player = col.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.DamagePlayer(enemyStats.dmg);
            }
        }
    }
}
