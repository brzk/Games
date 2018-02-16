using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour
{
    // Sound
    public AudioClip flameSound;
    public AudioClip laserSound;
    public AudioClip pistolSound;
    public AudioClip shotgunSound;
    private AudioSource source;

    public bool isGunActive = false;
    public bool isLaserActive = false;
    public bool isPistolActive = false;
    public bool isShotgunActive = false;

    public int damage = 1;
    public LayerMask whatToHit;

    public Transform ShotPrefabFlamethrower;
    public Transform ShotPrefabShotGun;
    public Transform ShotPrefabLaser;
    public Transform ShotPrefabPistol;
    public Transform mussleFlashPrefab;
    float timeToSpawn = 0;
    public float fireRate = 10;

    private float timeToSpawnEffect = 0;
    public float timeToSpawnRate = 10;

    private float timeToFire = 0;
    Transform firepoint;
    Transform firepoint2;
    Transform firepoint3;

    Animator animator;

    // Use this for initialization
    void Awake()
    {
        animator = GetComponentInParent<Animator>();
        firepoint = transform.FindChild("FirePoint");
        firepoint2 = transform.FindChild("FirePoint2");
        firepoint3 = transform.FindChild("FirePoint3");
        if (firepoint == null)
        {

            Debug.LogError("No firepoint?! What?!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPistolActive || isShotgunActive)
        {
            if (isPistolActive)
            {
                animator.SetInteger("WeaponId", 1);
            }
            else
            {
                animator.SetInteger("WeaponId", 2);
            }

            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            {
                fire();
            }
        }
        else
        {
            if ((Input.GetButton("Fire1") || Input.GetButton("Fire2")) && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                fire();
            }

            if (isLaserActive)
            {
                animator.SetInteger("WeaponId", 3);
            }
            else
            {
                animator.SetInteger("WeaponId", 4);
            }

        }
    }

    void fire()
    {


        if (Time.time >= timeToSpawn)
        {
            if (Time.time >= timeToSpawnEffect)
            {
                effect();

                if (isGunActive)
                    timeToSpawnEffect = Time.time + 0.8f / timeToSpawnRate;

                if (isPistolActive)
                    timeToSpawnEffect = Time.time + 0.9f / timeToSpawnRate;

                if (isShotgunActive)
                    timeToSpawnEffect = Time.time + 3.5f / timeToSpawnRate;

                if (isLaserActive)
                    timeToSpawnEffect = Time.time + 0.7f / timeToSpawnRate;


            }

            timeToSpawn = Time.time + 1 / fireRate;

        }


    }

    void effect()
    {
        
        if (isGunActive)
        {
            //sound
            source = GetComponent<AudioSource>();
            source.PlayOneShot(flameSound, 0.07f);
            Instantiate(ShotPrefabFlamethrower, firepoint.position, firepoint.rotation);
        }

        if (isLaserActive)
        {
            source = GetComponent<AudioSource>();
            source.PlayOneShot(laserSound, 0.07f);
            Instantiate(ShotPrefabLaser, firepoint.position, firepoint.rotation);
        }
        if (isPistolActive)
        {
            source = GetComponent<AudioSource>();
            source.PlayOneShot(pistolSound, 0.1f);
            Instantiate(ShotPrefabPistol, firepoint.position, firepoint.rotation);
        }

        if (isShotgunActive)
        {
            source = GetComponent<AudioSource>();
            source.PlayOneShot(shotgunSound, 0.4f);
            Instantiate(ShotPrefabShotGun, firepoint2.position, firepoint2.rotation);
            Instantiate(ShotPrefabShotGun, firepoint.position, firepoint.rotation);
            Instantiate(ShotPrefabShotGun, firepoint3.position, firepoint3.rotation);

        }


        Transform clone = Instantiate(mussleFlashPrefab, firepoint.position, firepoint.rotation) as Transform;
        clone.parent = firepoint;
        float size = Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.03f);

    }
}