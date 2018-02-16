using UnityEngine;
using System.Collections;

public class pickupShotgunSound : MonoBehaviour {

    private AudioSource shotgunPickSource;

    // Use this for initialization
    void Start () {
        shotgunPickSource = GetComponent<AudioSource>();
        shotgunPickSource.Play();
        Destroy(gameObject, 1.5f);
    } 
}
