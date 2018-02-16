﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;


public class Tutorial1 : MonoBehaviour {
	public GameObject leftHand;
	public GameObject handWithBlock;
	public GameObject emptyBlock;
	public GameObject text1;
	public GameObject text2;
	public GameObject darkBeckground;
	public GameObject ring;
	public GameObject text3;
	public GameObject handBlockRing;

	public GameObject rightHand;
	public GameObject text4;
	public  bool continueTutorial = false;
	public static bool continueTutorial1 = false;
	public static bool continueTutorial2 = false;
	private bool emptyBlockIsShowing = false;
	public static bool skipTutorial = false;
	public Button skipButton;

	// Use this for initialization
	void Start () {
		skipTutorial = false;
		emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
		continueTutorial1 = false;
		continueTutorial2 = false;
		LevelManager.isTutorialRunning = true;
		leftHand.GetComponent<SpriteRenderer>().enabled = true;
		handWithBlock.transform.position = new Vector3(-2.44f, -8.31f,0f);
		text1.transform.position = new Vector3(7.13f,-0.63f,0f);
		text2.GetComponent<SpriteRenderer>().enabled = false;
		handWithBlock.GetComponent<SpriteRenderer>().enabled = false;
		ring.GetComponent<SpriteRenderer>().enabled = false;
		text3.GetComponent<SpriteRenderer>().enabled = false;
		handBlockRing.GetComponent<SpriteRenderer>().enabled = false;
		rightHand.GetComponent<SpriteRenderer>().enabled = false;
		text4.GetComponent<SpriteRenderer>().enabled = false;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = true;
		StartCoroutine (Tutorial ());	
	}

	// Update is called once per frame
	void Update () {
		if (PauseMenuManager.MenuIsOpen && emptyBlockIsShowing) {
			emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
			skipButton.enabled = false;
			skipButton.image.enabled = false;
		} else if (!PauseMenuManager.MenuIsOpen && emptyBlockIsShowing) {
			emptyBlock.GetComponent<SpriteRenderer>().enabled = true;
			skipButton.enabled = true;
			skipButton.image.enabled = true;
		}
		if(continueTutorial1)
		{
			StartCoroutine (ContinueTutorial1 ());	
		}
		if(continueTutorial2)
		{
			StartCoroutine (ContinueTutorial2 ());	
		}

		if (skipTutorial)
		{
			continueTutorial1 = false;
			continueTutorial2 = false;

			leftHand.GetComponent<SpriteRenderer>().enabled = false;
			text1.GetComponent<SpriteRenderer>().enabled = false;
			text2.GetComponent<SpriteRenderer>().enabled = false;
			emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
			ring.GetComponent<SpriteRenderer>().enabled = false;
			handWithBlock.GetComponent<SpriteRenderer>().enabled = false;
			text3.GetComponent<SpriteRenderer>().enabled = false;
			handBlockRing.GetComponent<SpriteRenderer>().enabled = false;
			rightHand.GetComponent<SpriteRenderer>().enabled = false;
			text4.GetComponent<SpriteRenderer>().enabled = false;
			darkBeckground.GetComponent<SpriteRenderer>().enabled = false;
			continueTutorial = false;
			skipButton.enabled = false; // TODO: barak do this...
			skipButton.image.enabled = false; 
			LevelManager.isTutorialRunning = false;

		}
	}

	public IEnumerator Tutorial() {
		yield return new WaitForSeconds (2.2f);
		if (!skipTutorial) 
		{
			handWithBlock.GetComponent<SpriteRenderer>().enabled = true;
			leftHand.GetComponent<SpriteRenderer>().enabled = false;
			yield return new WaitForSeconds (0.3f);
			if (!skipTutorial) 
			{
			emptyBlock.GetComponent<SpriteRenderer> ().enabled = true;
			emptyBlockIsShowing = true;
			}
			yield return new WaitForSeconds (0.6f);
			if (!skipTutorial) 
			{
			text2.GetComponent<SpriteRenderer> ().enabled = true;
			}
		}
		yield return new WaitForSeconds (1.2f);
		text1.GetComponent<SpriteRenderer>().enabled = false;
		text2.GetComponent<SpriteRenderer>().enabled = false;
		handWithBlock.GetComponent<SpriteRenderer>().enabled = false;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = false;
		LevelManager.isTutorialRunning = false;
	}

	public IEnumerator ContinueTutorial1() 
	{
		if (!skipTutorial) {
			LevelManager.isTutorialRunning = true;
		}
		continueTutorial1 = false;
		yield return new WaitForSeconds (1f);
		if (!skipTutorial) {
			darkBeckground.GetComponent<SpriteRenderer> ().enabled = true;
			emptyBlock.transform.rotation = Quaternion.Euler (0, 0, 238);
			ring.GetComponent<SpriteRenderer> ().enabled = true;
			StartCoroutine (ringCoroutine ());
		}
		if (!skipTutorial) {
			text3.GetComponent<SpriteRenderer> ().enabled = true;
			rightHand.GetComponent<SpriteRenderer> ().enabled = true; 
			StartCoroutine (rightHandContinue ());
		}
	}
	public IEnumerator ringCoroutine()
	{
		int i = 0;
		do {
//			if (!skipTutorial) {
			yield return new WaitForSeconds (0.01f);
			ring.transform.eulerAngles = new Vector3 (0f, 0f, ring.transform.eulerAngles.z - 1.5f);  
			i++;
//			}
		} while(i < 33);
		do {
//			if (!skipTutorial) {
			yield return new WaitForSeconds (0.01f);
			ring.transform.eulerAngles = new Vector3 (0f, 0f, ring.transform.eulerAngles.z + 1.5f); 
			i--;
//			}
		} while(i > 0);
		do {
//			if (!skipTutorial) {
			yield return new WaitForSeconds (0.01f);
			ring.transform.eulerAngles = new Vector3 (0f, 0f, ring.transform.eulerAngles.z + 1.5f);  
			i++;
//			}
		} while(i < 33);
		do {
//			if (!skipTutorial) {
			yield return new WaitForSeconds (0.01f);
			ring.transform.eulerAngles = new Vector3 (0f, 0f, ring.transform.eulerAngles.z - 1.5f); 
			i--;
//			}
		} while(i > 0);

		do {
//			if (!skipTutorial) {
			yield return new WaitForSeconds (0.01f);
			ring.transform.eulerAngles = new Vector3 (0f, 0f, ring.transform.eulerAngles.z - 1.5f);  
			i++;
//			}
		} while(i < 33);
		do {
//			if (!skipTutorial) {
			yield return new WaitForSeconds (0.01f);
			ring.transform.eulerAngles = new Vector3 (0f, 0f, ring.transform.eulerAngles.z + 1.5f); 
			i--;
//			}
		} while(i > 0);
	}
	public IEnumerator rightHandContinue() 
	{
		
		yield return new WaitForSeconds (2.31f);
		rightHand.transform.position = new Vector3 (7.22f, -7.03f, 0f);
		int i = 0;
		do {
//			if (!skipTutorial) {
			yield return new WaitForSeconds (0.01f);
			rightHand.transform.position = new Vector3 (rightHand.transform.position.x - 0.05f
				, rightHand.transform.position.y + 0.07833f, 0f);
			i++;
//			}
		} while(i < 66);
		StartCoroutine (ringHandBlockCoroutine ());
	}
	public IEnumerator ringHandBlockCoroutine()
	{
		if (!skipTutorial) {
		handBlockRing.GetComponent<SpriteRenderer>().enabled = true; 
		}
		ring.GetComponent<SpriteRenderer>().enabled = false;
		rightHand.GetComponent<SpriteRenderer>().enabled = false; 
		yield return new WaitForSeconds (0.4f);
		int i = 0;
		do 
		{
//			if (!skipTutorial) {
			yield return new WaitForSeconds (0.01f);
			handBlockRing.transform.eulerAngles = new Vector3 (0f, 0f, handBlockRing.transform.eulerAngles.z + 1.5f);  
			i++;
//			}
		} while(i < 39);

		yield return new WaitForSeconds (1f);
		handBlockRing.GetComponent<SpriteRenderer>().enabled = false;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = false;
		text3.GetComponent<SpriteRenderer>().enabled = false;
		LevelManager.isTutorialRunning = false;
	}

	public IEnumerator ContinueTutorial2() 
	{	
		if (!skipTutorial) {
			LevelManager.isTutorialRunning = true;
		}
		continueTutorial2 = false;
		yield return new WaitForSeconds (1f);
		if (!skipTutorial) {
			text4.GetComponent<SpriteRenderer> ().enabled = true;
			darkBeckground.GetComponent<SpriteRenderer> ().enabled = true;
		}
		yield return new WaitForSeconds (2f);
		text4.GetComponent<SpriteRenderer>().enabled = false;
		darkBeckground.GetComponent<SpriteRenderer>().enabled = false;
		emptyBlock.layer = 10;
		emptyBlock.GetComponent<SpriteRenderer> ().enabled = false;
		emptyBlockIsShowing = false;
		skipButton.enabled = false;
		skipButton.image.enabled = false; 
		LevelManager.isTutorialRunning = false;
	}

	public void HandlePressStart()
	{
		SoundManager.playButtonClick = true;
		emptyBlock.GetComponent<SpriteRenderer>().enabled = false;
		emptyBlockIsShowing = false;
	}

	public void HandleSkipTutorial()
	{	
		SoundManager.playButtonClick = true;	
		skipTutorial = true;
	}
}