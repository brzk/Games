using UnityEngine;
using System.Collections;

public class pickupLaserSound : MonoBehaviour {

    private AudioSource laserPickSource;

    // Use this for initialization
    void Start()
    {
        laserPickSource = GetComponent<AudioSource>();
        laserPickSource.Play();
        Destroy(gameObject, 1.5f);
    }
}
