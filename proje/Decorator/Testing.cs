using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {
    public GameObject Butterfly;
    DragonDecorator decorator;
	// Use this for initialization
	void Start () {
        GameObject go = (GameObject)Instantiate(Resources.Load("Dragon"));
         = go.GetComponent<Sprite>();
        if (PlayerPrefs.GetInt("HighScore") >= 500)
        {
        Sprite.DestroyObject(Butterfly);
            decorator.upgrade();
            Debug.Log("Butterfly upgraded to Dragon");
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
