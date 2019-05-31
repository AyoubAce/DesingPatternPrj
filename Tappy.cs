using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Tappy : MonoBehaviour {
    Rigidbody2D rigitbody;
    Quaternion downRotation;
    Quaternion upRptaion;
    public float tapping = 10;
    public Vector3 startPosition;
    public float tilt= 5;

    GManager game;

    public delegate void PlayerDel();
    public static event PlayerDel OnDeath;
    public static event PlayerDel OnScore;

    public AudioSource tappingAudio;
    public AudioSource onDeathAudio;
    public AudioSource onScoreAudio;

    // Use this for initialization
    void Start () {
        rigitbody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90);
        upRptaion= Quaternion.Euler(0, 0, 30);
        game = GManager.instance;
        rigitbody.simulated = false;
        

    }
	
	// Update is called once per frame
	void Update () {
        if (game.GameOver) return;
        if (Input.GetMouseButtonDown(0))
        {
           
            transform.rotation = upRptaion;
            rigitbody.AddForce(Vector2.up * tapping, ForceMode2D.Force);
            rigitbody.velocity = Vector3.zero;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tilt * Time.deltaTime); 
            }

    private void OnEnable()
    {
        GManager.OnGStarted += OnGStarted;
        GManager.OnGOver += OnGOver;
    }
    private void OnDisable()
    {
        GManager.OnGStarted -= OnGStarted;
        GManager.OnGOver -= OnGOver;
    }

    void OnGStarted()
    {
        rigitbody.velocity = Vector3.zero;
        rigitbody.simulated = true;
    }
   
    void OnGOver()
    {
        transform.localPosition = startPosition;
        transform.rotation = Quaternion.identity;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeadZone")
        {
            rigitbody.simulated = false;
            //Register a score event
            //audio
            OnDeath(); // event sent to game manager
        }
        if (collision.gameObject.tag == "ScoreZone")
        {
            //Register a dead event
            //play a sound
            OnScore(); // event sent to gManager
        }
    }
}
