using UnityEngine;
using System.Collections;

public class SwitchToPistolScript : MonoBehaviour {
    public Transform pickupPistolSoundTrans;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(pickupPistolSoundTrans);
            GunScript gun = col.gameObject.GetComponentInChildren<GunScript>();
            gun.isPistolActive = true;
            gun.isShotgunActive = false;
            gun.isGunActive = false;
            gun.isLaserActive = false;
           
            Destroy(gameObject);
        }
    }
}
