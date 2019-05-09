using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class HighScoreTxt : MonoBehaviour {

    Text highScore;
    private void OnEnable()
    {
        highScore = GetComponent<Text>();
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }


}
