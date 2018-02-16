using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{

    public Image threeStars;
    public Image twoStars;
    public Image oneStar;
    public Image zeroStar;
    public Image star;

    public float starPositionX;
    public float starPositionXChange;
    public float starPositionY;

    public Text scoreText;

    void Start()
    {
        //Debug.Log(star.transform.position);
        threeStars.GetComponent<Image>().enabled = false;
        twoStars.GetComponent<Image>().enabled = false;
        oneStar.GetComponent<Image>().enabled = false;
        zeroStar.GetComponent<Image>().enabled = false;        
        scoreText.GetComponent<Text>().enabled = false;

        star.GetComponent<Image>().enabled = false;
    }



    public void HandleLevelEnd()
    {
        StartCoroutine(ShowPoints());
        StartCoroutine(ChangeStar());
    }    

    public IEnumerator ShowPoints()
    {
        scoreText.GetComponent<Text>().enabled = true;
        
        int currentScore = 0;
        int randomScore = (int)Random.Range(1000f, 3000f);
        int addPoints = randomScore / 135;

        do
        {
            scoreText.text = "" + currentScore;
            currentScore += addPoints;
            yield return new WaitForSeconds(0.01f);
        } while (currentScore <= randomScore);
    }



    public IEnumerator ChangeStar()
    {
        zeroStar.GetComponent<Image>().enabled = false;
        oneStar.GetComponent<Image>().enabled = true;
        star.GetComponent<Image>().enabled = true;        
        star.GetComponent<RectTransform>().transform.position = new Vector3(starPositionX - starPositionXChange, starPositionY, 0f);
        int i = 0;

        do
        {
            yield return new WaitForSeconds(0.01f);
            star.GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0f);
            i++;
        } while (i < 10);
        do
        {
            yield return new WaitForSeconds(0.01f);
            star.GetComponent<RectTransform>().localScale -= new Vector3(0.02f, 0.02f, 0f);
            i--;
        } while (i > 0);
        star.GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(0.5f);

        oneStar.GetComponent<Image>().enabled = false;
        twoStars.GetComponent<Image>().enabled = true;
        star.GetComponent<Image>().enabled = true;        
        star.GetComponent<RectTransform>().transform.position = new Vector3(starPositionX, starPositionY, 0f);

        do
        {
            yield return new WaitForSeconds(0.01f);
            star.GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0f);
            i++;
        } while (i < 10);
        do
        {
            yield return new WaitForSeconds(0.01f);
            star.GetComponent<RectTransform>().localScale -= new Vector3(0.02f, 0.02f, 0f);
            i--;
        } while (i > 0);
        star.GetComponent<Image>().enabled = false;

        yield return new WaitForSeconds(0.5f);

        twoStars.GetComponent<Image>().enabled = false;
        threeStars.GetComponent<Image>().enabled = true;
        star.GetComponent<Image>().enabled = true;        
        star.GetComponent<RectTransform>().transform.position = new Vector3(starPositionX + starPositionXChange, starPositionY, 0f);

        do
        {
            yield return new WaitForSeconds(0.01f);
            star.GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0f);
            i++;
        } while (i < 10);
        do
        {
            yield return new WaitForSeconds(0.01f);
            star.GetComponent<RectTransform>().localScale -= new Vector3(0.02f, 0.02f, 0f);
            i--;
        } while (i > 0);
        star.GetComponent<Image>().enabled = false;
    }
}
