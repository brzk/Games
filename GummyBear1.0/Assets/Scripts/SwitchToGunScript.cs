using UnityEngine;
using System.Collections;

public class SwitchToGunScript : MonoBehaviour {
    public Transform pickupFlamethrowerSoundTrans;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(pickupFlamethrowerSoundTrans);
            GunScript gun = col.gameObject.GetComponentInChildren<GunScript>();
            gun.isGunActive = true;
            gun.isShotgunActive = false;        
            gun.isLaserActive = false;
            gun.isPistolActive = false;
            Destroy(gameObject);
        }
    }
    }
