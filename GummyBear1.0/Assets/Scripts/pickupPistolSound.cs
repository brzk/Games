using UnityEngine;
using System.Collections;

public class pickupPistolSound : MonoBehaviour {

    private AudioSource pistolPickSource;

    // Use this for initialization
    void Start()
    {
        pistolPickSource = GetComponent<AudioSource>();
        pistolPickSource.Play();
        Destroy(gameObject, 1.5f);
    }
}
