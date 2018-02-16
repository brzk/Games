using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class barScript : MonoBehaviour {

    public Image bar;
	
	// Update is called once per frame
	void Update () {
        bar.fillAmount = Player.playerStats.HP / 100f;
	}
}
