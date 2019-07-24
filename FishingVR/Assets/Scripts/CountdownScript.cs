using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    void Start()
    {
        //timer = mainTimer;
    }

    void Update()
    {

        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
        }

        else if (timer <= 0.0f && !doOnce)
        {
            changeScore.gameStart = 0;
            changeScore.haveRod = 0;
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
            GameOver();
        }
    }

   

    public void ResetBtn()
    {
        changeScore.gameStart = 1;
        changeScore.gameReset = 1;
        timer = mainTimer;
        canCount = true;
        doOnce = false;
        
    }

    void GameOver()
    {
        //Load a new scene
    }
}
