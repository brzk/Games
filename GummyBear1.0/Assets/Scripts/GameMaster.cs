 using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
    public int numOfFactories;
    public static GameMaster gm;
    public int currentStage;
    AudioSource source;
    private int numOfEnemies;

    public AudioClip stationDestroy;
    

    void Start() {
        if (Application.loadedLevelName.Equals("Level 5"))
        {
            numOfEnemies = 1;
        }
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
     //   Debug.LogError("currentStage" + (gm.currentStage + 1));
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 3;

    public IEnumerator RespawnPlayer() {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public static void killPlayer (Player player)
    {gm.currentStage= PlayerPrefs.GetInt("currentStage");
        Destroy(player.gameObject);
        Application.LoadLevel("menuLooser");
        PlayerPrefs.SetInt("loosingStage", gm.currentStage);
        // gm.StartCoroutine(gm.RespawnPlayer()); 
    }

    public static void KillEnemy(EnemyScript enemy)
    {
        gm.numOfEnemies--;
        Destroy(enemy.gameObject);

        if (gm.numOfFactories == 0 && gm.numOfEnemies == 0)
        {
            Application.LoadLevel("mapScene" + (gm.currentStage + 1));
        }
    }

    public static void addEnemyCounter()
    {
        gm.numOfEnemies++;
    }

    public static void killStation(station1 station)
    {
        gm.currentStage = PlayerPrefs.GetInt("currentStage");
        //sound
        gm.source = gm.GetComponent<AudioSource>();
         gm.source.PlayOneShot(gm.stationDestroy, 1.0f);
        Destroy(station.gameObject);
        gm.numOfFactories--;
        if (gm.numOfFactories == 0 && gm.numOfEnemies == 0)
        {
            Application.LoadLevel("mapScene" + (gm.currentStage +1));
           // PlayerPrefs.SetInt("currentStage", (gm.currentStage + 1));
          //  Debug.LogError("currentStage" + (gm.currentStage + 1));
        }

    }
}
