using UnityEngine;
using System.Collections;

public class PistolScript : MonoBehaviour {

	public int damage = 1;
	public LayerMask whatToHit;
	
	public Transform ShotPrefab;
	public Transform mussleFlashPrefab;
	float timeToSpawn = 0;
	public float fireRate = 10;
	private float timeToSpawnEffect = 0;
	public float timeToSpawnRate = 10;
	//private float timeToFire;
	Transform firepoint;

	// Use this for initialization
	void Awake () {
		firepoint = transform.FindChild("FirePoint");
		if (firepoint == null) {

            Debug.LogError("No firepoint?! What?!");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) {
			fire ();
		}
		
		/*
		else {
			if ((Input.GetButton("Fire1") || Input.GetButton("Fire2")) && Time.time > timeTofire) {
				timeTofire = Time.time + 1 / fireRate;
				fire ();
			}
		}
		*/
	}
	
	void fire () {
		Vector2 mousePostion = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 
		                                    Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		
		Vector2 firePointPosition = new Vector2 (firepoint.position.x, firepoint.position.y);

		// This line say where the shot is going to, the 3rd parameter is how much should it fly
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePostion-firePointPosition, 100, whatToHit);
		if (Time.time >= timeToSpawn) {
			if (Time.time >= timeToSpawnEffect) {
				effect ();
				timeToSpawnEffect = Time.time + 1 / timeToSpawnRate;   
			}

			timeToSpawn = Time.time + 1/fireRate;
		} 
		//Debug.DrawLine (firePointPosition, (mousePostion-firePointPosition) * 100, Color.black);
		if (hit.collider != null) {
			//Debug.DrawLine (firePointPosition, hit.point, Color.red);
			//Debug.Log ("We hit " + hit.collider.name + " and did " + damage + "damage");
	/*
			EnemyScript enemy = hit.collider.GetComponent<EnemyScript>();
            
			if (enemy != null) {
				enemy.DamageEnemy(damage);
			}
            */
		}
	}
	
	void effect () {
		Instantiate (ShotPrefab, firepoint.position, firepoint.rotation);
		Transform clone = Instantiate(mussleFlashPrefab, firepoint.position, firepoint.rotation) as Transform;
		clone.parent = firepoint;
		float size = Random.Range(0.6f, 0.9f);
		clone.localScale = new Vector3(size, size, size);
		Destroy(clone.gameObject, 0.03f);
	}
	
}