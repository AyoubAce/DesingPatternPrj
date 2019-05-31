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


    public static GManager instance=null;
   // public delegate void gDelegate();
   // public static event gDelegate OnGStarted; //event sent to tappy
    //public static event gDelegate OnGOver;

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
       
    }