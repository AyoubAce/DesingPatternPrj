using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDecorator : MonoBehaviour {
    public GameObject butterfly;
    public GameObject Dragon;
    GManager game = GManager.instance;
    PlayerPrefs playerPrefs;
    PlayerPrefs
    public DragonDecorator(Dragon)
    {
        
        GameObject butterfly = (GameObject)Instantiate(Resources.Load("Dragon"), butterfly.noseTransform.position, Quaternion.identity);
        go.transform.parent = Dragon.noseTransform;
        
    }
    public void upgrade()
    {
        
        Sprite dragon = Resources.Load("Dragon", typeof(Sprite)) as Sprite;
    }
    

}
