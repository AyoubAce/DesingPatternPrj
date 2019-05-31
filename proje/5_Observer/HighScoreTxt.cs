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
        
        int score = PlayerPrefs.GetInt("HighScore");
        if(score== 25) { Debug.Log("WARRIOR"); }
        if (score == 50) { Debug.Log("ELITE"); }
        if (score == 100) { Debug.Log("MASTER"); }
        if (score == 200) { Debug.Log("GRAND MASTER"); }
        if (score == 500) { Debug.Log("LEGEND"); }
        if (score == 1000) { Debug.Log("MYTHIC"); }

    }
    


}
