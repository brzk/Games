using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

//*********TODO:
//ADD HP TO THE STATION *******

public class station1 : MonoBehaviour {

    
    public Transform prefab;
    public int hp;
    public int LeftOrRight = 0;

    public AudioClip stationSound;
    private AudioSource source;
    public StationStats stationStats = new StationStats();

    [System.Serializable]
    public class StationStats
    {
        public int HP = 15;
    }

    int counter = 1; //it helps in the logic of dealing with the time

    float time;

    public int TIME_BETWEEN_INTERVALS = 10;
    public int NUMBER_OF_APPEARENCES_EACH_INTERVAL = 7;
    public float TIME_BETWEEN_INNER_INTERVAL_APPEARENCE = 0.8f;

    // Update is called once per frame
    void Update() {

        //the function checks if the seconds divide in TIME_BETWEEN_INTERVALS
        time += Time.deltaTime;
        if ((int)time % TIME_BETWEEN_INTERVALS == 0)
        {
           //sound
           source = GetComponent<AudioSource>();
           source.PlayOneShot(stationSound, 0.2f);


            if (LeftOrRight == 0)
            {
                GameMaster.addEnemyCounter();
                Instantiate(prefab, transform.position, Quaternion.identity);
            }
            else
            {
                GameMaster.addEnemyCounter();
                Instantiate(prefab, new Vector3(transform.position.x-0.1f, transform.position.y, transform.position.z), Quaternion.identity);
            }

            //if the factory already executed NUMBER_OF_APPEARENCES_EACH_INTERVAL of the prefab, increase time in 1 in order to avoid further executing
            //otherwise, increase time in TIME_BETWEEN_INTERVALS- TIME_BETWEEN_INNER_INTERVAL_APPEARENCE, in order to wait that time between each appearence
            if (counter% NUMBER_OF_APPEARENCES_EACH_INTERVAL == 0)
            {
                time = time + 1;
            }
            else
            { time = time + (TIME_BETWEEN_INTERVALS- TIME_BETWEEN_INNER_INTERVAL_APPEARENCE); } 
            counter++;
           
        }
        
        if (counter % NUMBER_OF_APPEARENCES_EACH_INTERVAL == 0)
        {
            counter = 0;

        }

    }

    public void DamageStation(int amountOfDamage)
    {
        stationStats.HP -= amountOfDamage;
        
        //Debug.LogError("Player hit");
        if (stationStats.HP <= 0)
        {
            spcialEffectHelperFactory.Instance.Explosion(transform.position);
            GameMaster.killStation(this);
        }
    }
}

