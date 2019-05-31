using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GManager : MonoBehaviour {
    public GameObject startMenu;
    public GameObject gameOverMenu;
    public GameObject countDownMenu;
    
    public Text scoreTxt;
    private GManager() { }


    public static GManager instance;
    public delegate void gDelegate();
    public static event gDelegate OnGStarted; //event sent to tappy
    public static event gDelegate OnGOver;

    enum STATE {none,start,GameOver,countDown}
    int score = 0;
    bool game_over = true;
    public bool GameOver { get { return game_over; } } // gameOver accessible but not modifiable

    public static GManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void Awake()
    {

         if (instance == null) {instance = this; }
       
        //instance = new GManager();
    }
  
    void setStat(STATE state)
    {
        switch (state)
        {
            case STATE.none:
                startMenu.SetActive(false);
                gameOverMenu.SetActive(false);
                countDownMenu.SetActive(false);
                break;
            case STATE.start:
                startMenu.SetActive(true);
                gameOverMenu.SetActive(false);
                countDownMenu.SetActive(false);
                break;
            case STATE.GameOver:
                startMenu.SetActive(false);
                gameOverMenu.SetActive(true);
                countDownMenu.SetActive(false);
                break;
            case STATE.countDown:
                startMenu.SetActive(false);
                gameOverMenu.SetActive(false);
                countDownMenu.SetActive(true);
                break;

        }
    }

    public void gOverConfirm()
    {
        //activated when replay button is hit
        OnGOver(); //event sent to tappy
        scoreTxt.text = "0";
        setStat(STATE.start);

    }
    public void GSTART()
    {
        //activated when play button is hit
     
        setStat(STATE.countDown);
    }
    
    private void OnEnable()
    {
        CountDownCode.OnCountDownDone += OnCountDownDone;
        Tappy.OnDeath += OnDeath_player;
        Tappy.OnScore += OnScore_player;
    }
   
    private void OnDisable()
    {

        CountDownCode.OnCountDownDone -= OnCountDownDone;
        Tappy.OnDeath -= OnDeath_player;
        Tappy.OnScore -= OnScore_player;
    }
    

    void OnCountDownDone()
    {
        setStat(STATE.none);
        OnGStarted(); //event sent to tappy
        score = 0;
        game_over = false;
    }

     void OnDeath_player()
     {
         game_over = true;
         int saved_score = PlayerPrefs.GetInt("HighScore");
         if(score> saved_score)
         {
             PlayerPrefs.SetInt("HighScore", score);
         }
         setStat(STATE.GameOver);
     }
     void OnScore_player()
     {
         score++;
         scoreTxt.text = score.ToString();

     }
   

}

