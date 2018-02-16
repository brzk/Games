using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	
	public Vector2 speed = new Vector2 (6, 6);
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (speed.x * inputX, speed.y * inputY, 0);
		movement *= Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(inputX + inputY));
        transform.Translate (movement);
	}
}
