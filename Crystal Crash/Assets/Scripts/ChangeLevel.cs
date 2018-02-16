﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ChangeLevel : MonoBehaviour
{
	public int numOfCloseLevel = 0;
	public int numOfGainedStars = 0;
	public int numOfLevels = 0;
	public static int lastLevel = 20; 
	public static int[] starsArray = new int[20];
	public Button[] buttonsArray;
	public Text starsText;
	public Text blocksText;


	// Use this for initialization
	void Start ()
	{				



//		GameControl.control.starsArray[0] = 0;
//		GameControl.control.starsArray[1] = 3;
//		GameControl.control.starsArray[2] = 3;
//		GameControl.control.starsArray[3] = 3;
//		GameControl.control.starsArray[4] = 3;
//		GameControl.control.starsArray[5] = 3;
//		GameControl.control.starsArray[6] = 3;
//		GameControl.control.starsArray[7] = 3;
//		GameControl.control.starsArray[8] = 3;
//		GameControl.control.starsArray[9] = 3;
//		GameControl.control.starsArray[10] = 3;
//		GameControl.control.starsArray[11] = 3;
//		GameControl.control.starsArray[12] = 3;
//		GameControl.control.starsArray[13] = 3;
//		GameControl.control.starsArray[14] = 3;
//		GameControl.control.starsArray[15] = 3;
//		GameControl.control.starsArray[16] = 3;
//		GameControl.control.starsArray[17] = 3;
//		GameControl.control.starsArray[18] = 3;
//		GameControl.control.starsArray[19] = 3;

//		GameControl.control.starsArray[2] = -1;
//		GameControl.control.starsArray[3] = -1;
//		GameControl.control.starsArray[4] = -1;
//		GameControl.control.starsArray[5] = -1;
//		GameControl.control.starsArray[6] = -1;
//		GameControl.control.starsArray[7] = -1;
//		GameControl.control.starsArray[8] = -1;
//		GameControl.control.starsArray[9] = -1;
//		GameControl.control.starsArray[10] = -1;
//		GameControl.control.starsArray[11] = -1;
//		GameControl.control.starsArray[12] = -1;
//		GameControl.control.starsArray[13] = -1;
//		GameControl.control.starsArray[14] = -1;
//		GameControl.control.starsArray[15] = -1;
//		GameControl.control.starsArray[16] = -1;
//		GameControl.control.starsArray[17] = -1;
//		GameControl.control.starsArray[18] = -1;
//		GameControl.control.starsArray[19] = -1;
//		GameControl.control.starsArray[10] = -1;
//		GameControl.control.numOfGainedStars = 0;
//		GameControl.control.Save ();
		HandleCheckLevelsStars();
		Debug.Log(GameControl.control.numOfLevels);
		Debug.Log(GameControl.control.numOfCloseLevel);

		starsText.text =  GameControl.control.numOfGainedStars +  "/" + ((GameControl.control.numOfLevels - GameControl.control.numOfCloseLevel) * 3);
	}

	void Update () {
		blocksText.text = GameControl.control.numOfBlocks.ToString();
		if (StoreManager.MenuIsOpen) {
			blocksText.GetComponent<Text> ().enabled = false;
		} else {
			blocksText.GetComponent<Text> ().enabled = true;
		}
	}

	public static int getCurrentLevelIndex() {
		Regex regex = new Regex (".+([0-9]+)$");
		Match match = regex.Match (Application.loadedLevelName);
		string levelString = match.Groups[1].Value;
		int levels = int.Parse (levelString);
		return levels;
	}

	public void HandleCheckLevelsStars ()
	{		
		int j = getCurrentLevelIndex();
		j = (j - 1) * 10;

		for (int i = 0; i < numOfLevels; i++) {
			setLevelImage(buttonsArray[i], GameControl.control.starsArray[j]);
			j++;
		}
	}

	public void setLevelImage (Button button, int numOfStars)
	{
		GameObject locked = button.transform.FindChild("lockImage").gameObject;
		switch (numOfStars) {
		case -1:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/lockLevel");
			locked.GetComponent<Image> ().enabled = true;
			button.GetComponent<Button>().enabled = false;
			numOfCloseLevel++;
			break;
		
		case 0:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/zeroStars");
			locked.GetComponent<Image> ().enabled = false;
			button.GetComponent<Button>().interactable = true;
			break;
	
		case 1:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/oneStars");
			locked.GetComponent<Image> ().enabled = false;
			button.GetComponent<Button>().interactable = true;
			numOfGainedStars++;
			break;

		case 2:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/twoStars");
			locked.GetComponent<Image> ().enabled = false;
			button.GetComponent<Button>().interactable = true;
			numOfGainedStars = numOfGainedStars + 2;
			break;
		case 3:
			button.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Levels/threeStars");
			locked.GetComponent<Image> ().enabled = false;
			button.GetComponent<Button>().interactable = true;
			numOfGainedStars = numOfGainedStars + 3;
			break;
		}
	}

	public void HandlePressReturnButteun ()
	{
		SoundManager.playButtonClick = true;
		Application.LoadLevel ("StartMenu");
	}

	public void HadleLoadLevel (int Level)
	{
		SoundManager.playButtonClick = true;
		if (!StoreManager.MenuIsOpen) {
			SoundManager.inLevel = true;
			Application.LoadLevel ("Level" + Level);
		}
	}


	public void HadleLoadLevels (int Levels)
	{
		SoundManager.playButtonClick = true;
		Application.LoadLevel ("Levels" + Levels);
	}
}
