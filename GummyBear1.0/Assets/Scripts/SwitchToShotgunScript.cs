using UnityEngine;
using System.Collections;

public class SwitchToShotgunScript : MonoBehaviour {

    public Transform pickupShotgunSoundTrans;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(pickupShotgunSoundTrans);
            GunScript gun = col.gameObject.GetComponentInChildren<GunScript>();
            gun.isShotgunActive = true;
            gun.isGunActive = false;
            gun.isLaserActive = false;
            gun.isPistolActive = false;
            Destroy(gameObject);
        }
    }
}
