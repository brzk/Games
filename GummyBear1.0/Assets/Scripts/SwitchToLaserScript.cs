using UnityEngine;
using System.Collections;

public class SwitchToLaserScript : MonoBehaviour {
    public Transform pickupLaserSoundTrans;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(pickupLaserSoundTrans);
            GunScript gun = col.gameObject.GetComponentInChildren<GunScript>();
            gun.isLaserActive = true;
            gun.isShotgunActive = false;
            gun.isGunActive = false;
            gun.isPistolActive = false;
            Destroy(gameObject);
        }
    }
}
