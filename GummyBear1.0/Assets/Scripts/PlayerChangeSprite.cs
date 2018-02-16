using UnityEngine;
using System.Collections;

public class PlayerChangeSprite : MonoBehaviour {

    public Sprite faceDown;
    public Sprite faceUp;
    public Sprite faceRight;
    public Sprite faceLeft;
    public Sprite faceUpperRight;
    public Sprite faceUpperLeft;
    public Sprite faceDownLeft;
    public Sprite faceDownRight;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {

        if (!(Time.timeScale == 0))
        {

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
            lookPos = lookPos - transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
            if (((angle >= -180) && (angle < -157.5)) || ((angle > 157.5) && (angle <= 180)))
            {
                angle = 180;
            }
            animator.SetFloat("angle", angle);
            /*
            // Changing the faceing of the charecter
            if ((angle <= 22.5) && (angle >= -22.5))
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = faceRight;
            }
            else if ((angle > 22.5) && (angle <= 67.5))
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = faceUpperRight;
            }
            else if ((angle <= 112.5) && (angle > 67.5))
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = faceUp;
            }
            else if ((angle > 112.5) && (angle <= 157.5))
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = faceUpperLeft;
            }
            else if (((angle >= -180) && (angle < -157.5)) || ((angle > 157.5) && (angle <= 180)))
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = faceLeft;
            }
            else if ((angle < -112.5) && (angle >= -157.5))
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = faceDownLeft;
            }
            else if ((angle >= -112.5) && (angle < -67.5))
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = faceDown;
            }
            else if ((angle < -22.5) && (angle >= -67.5))
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = faceDownRight;
            }
            */
        }
    }
}
