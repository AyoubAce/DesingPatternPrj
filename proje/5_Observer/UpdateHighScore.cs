using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public interface High_score
    {
        void OnDeath_player();
        void OnScore_player();
    }

   public class UpdateHighScore : High_score
    {
    GManager g= GManager.instance;
        public void OnDeath_player()
        {
           g.game_over = true;
            int saved_score = PlayerPrefs.GetInt("HighScore"); 
            if (g.score > saved_score)
            {
                PlayerPrefs.SetInt("HighScore", g.score);
            }
            g.setStat(STATE.GameOver);

        }
        public void OnScore_player()
        {
           g.score++;
            g.scoreTxt.text = g.score.ToString();
         
        }
    }