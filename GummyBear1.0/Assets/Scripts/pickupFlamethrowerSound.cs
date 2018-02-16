using UnityEngine;
using System.Collections;

public class pickupFlamethrowerSound : MonoBehaviour {

    private AudioSource flamethrowerPickSource;

    // Use this for initialization
    void Start()
    {
        flamethrowerPickSource = GetComponent<AudioSource>();
        flamethrowerPickSource.Play();
        Destroy(gameObject, 1.5f);
    }
}
