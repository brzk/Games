using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public AudioClip stationSound;
    private AudioSource source;


    
    Animator animator;

    [System.Serializable]
    public class PlayerStats {
        public int HP = 100;
    }

    public static PlayerStats playerStats;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerStats = new PlayerStats();
    }

    

    public void DamagePlayer(int amountOfDamage) {
        playerStats.HP -= amountOfDamage;
        Debug.LogError("hp:"+ playerStats.HP);

        // animator
        animator.SetBool("isBearHit", true);
      
        //sound
        source = GetComponent<AudioSource>();
        source.PlayOneShot(stationSound, 0.2f);

        //Debug.LogError("Player hit");
        if (playerStats.HP <= 0)
        {
            GameMaster.killPlayer(this); 
        }

        StartCoroutine(DelayNextFunc());
        
    }

    IEnumerator DelayNextFunc()
    {
        yield return new WaitForSeconds(0.1f);
        
        animator.SetBool("isBearHit", false);
    }
}
