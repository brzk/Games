using UnityEngine;
using System.Collections;

public class moveBulletFt : MonoBehaviour
{

    public int moveSpeed = 10;
    public int dmg = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);

        Destroy(gameObject, 0.3f);
    }

    // Collide something
    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Wall") || (col.gameObject.tag == "Obstycals"))
        {
            Destroy(gameObject);
        }
        if ((col.gameObject.tag == "Enemy1") || (col.gameObject.tag == "Enemy2") || (col.gameObject.tag == "Enemy3") || (col.gameObject.tag == "Enemy4") || (col.gameObject.tag == "Enemy5"))
        {
            Destroy(gameObject);

            EnemyScript enemy = col.gameObject.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                enemy.DamageEnemy(dmg, this.gameObject.tag);
            }
        }

        if (col.gameObject.tag == "station")
            Destroy(gameObject);

        station1 station = col.gameObject.GetComponent<station1>();
        if (station != null)
        {
            station.DamageStation(dmg);
        }
    }
}