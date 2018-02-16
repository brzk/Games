using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

//*********TODO:
//ADD HP TO THE STATION *******

public class FinalBossStation : MonoBehaviour
{


    public Transform prefab1;
    public Transform prefab2;
    public Transform prefab3;
    public Transform prefab4;

    public int hp;
    public int LeftOrRight = 0;

    int counter = 1; //it helps in the logic of dealing with the time

    float time;

    public int TIME_BETWEEN_INTERVALS = 10;
    public int NUMBER_OF_APPEARENCES_EACH_INTERVAL = 7;
    public float TIME_BETWEEN_INNER_INTERVAL_APPEARENCE = 0.8f;

    // Update is called once per frame
    void Update()
    {

        //the function checks if the seconds divide in TIME_BETWEEN_INTERVALS
        time += Time.deltaTime;
        if ((int)time % TIME_BETWEEN_INTERVALS == 0 && (int)time!=0)
        {

            Instantiate(prefab1, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(prefab2, new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(prefab3, new Vector3(transform.position.x , transform.position.y + 1f, transform.position.z), Quaternion.identity);
            Instantiate(prefab4, new Vector3(transform.position.x , transform.position.y -1f, transform.position.z), Quaternion.identity);
            GameMaster.addEnemyCounter();
            GameMaster.addEnemyCounter();
            GameMaster.addEnemyCounter();
            GameMaster.addEnemyCounter();

            //if the factory already executed NUMBER_OF_APPEARENCES_EACH_INTERVAL of the prefab, increase time in 1 in order to avoid further executing
            //otherwise, increase time in TIME_BETWEEN_INTERVALS- TIME_BETWEEN_INNER_INTERVAL_APPEARENCE, in order to wait that time between each appearence
            if (counter % NUMBER_OF_APPEARENCES_EACH_INTERVAL == 0)
            {
                time = time + 1;
            }
            else
            { time = time + (TIME_BETWEEN_INTERVALS - TIME_BETWEEN_INNER_INTERVAL_APPEARENCE); }
            counter++;

        }

        if (counter % NUMBER_OF_APPEARENCES_EACH_INTERVAL == 0)
        {
            counter = 0;

        }

    }
}

