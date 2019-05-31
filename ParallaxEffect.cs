using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParallaxEffect : MonoBehaviour {

	public class PObject   //poolObject
    {
        public Transform transform;
        public bool inUse;
        public PObject(Transform tr) { transform = tr; }
        public void use() { inUse = true; }
        public void dispose() { inUse = false; }
    }
    [System.Serializable]
    public struct Yspawn_Range
    {
        public float min;
        public float max;
    }

    public GameObject prefab;
    public int pool_size;
    public float shift_speed;
    public float spawn_Rate;

    public Yspawn_Range yspawn_Range;
    public Vector3 default_spawnPosition;
    public bool spawnImmediate; //particle preware
    public Vector3 immediate_spawnPosition;
    public Vector2 target_aspect_ratio;

    float spawn_timer;
    float target_aspect;
    PObject[] pool_objects;

    GManager game;

    private void Awake()
    {
        Configuration();
    }
    private void Start()
    {
        game = GManager.instance;
    }
    private void OnEnable()
    {
        GManager.OnGOver += OnGOver;
    }
    private void OnDisable()
    {
        GManager.OnGOver -= OnGOver;
        
    }
    void OnGOver()  //on game over confirmed
    {
        for (int j = 0; j < pool_objects.Length; j++)
        {
            pool_objects[j].dispose();
            pool_objects[j].transform.position = Vector3.one * 1000;
        } 
        if (spawnImmediate) { SpawnImmediate(); }
    }
    void Update()
    {
        if (game.GameOver) return;

        Shifting();
        spawn_timer += Time.deltaTime;
        if(spawn_timer> spawn_Rate)
        {
            Spawn();
            spawn_timer = 0;
        }
    }
    void Configuration()
    {
        target_aspect = target_aspect_ratio.x / target_aspect_ratio.y;
        pool_objects = new PObject[pool_size];
        for(int i = 0; i < pool_objects.Length; i++)
        {
            GameObject go = Instantiate(prefab) as GameObject;
            Transform tr = go.transform;
            tr.SetParent(transform);
            tr.position = Vector3.one * 1000;  //off screen *1000
            pool_objects[i] = new PObject(tr);
        }
        if (spawnImmediate) { SpawnImmediate(); } // we check the spawnImmediate in order not to create the pool again
    }
    void Spawn()
    {
        Transform tr = GetPool_object();
        if (tr == null) return; // if true, this indicates that poolSize is too small..
        Vector3 posit = Vector3.zero;
        posit.x = (default_spawnPosition.x * Camera.main.aspect)/target_aspect;
        posit.y = Random.Range(yspawn_Range.min, yspawn_Range.max);
        tr.position = posit;
    }
    void SpawnImmediate() 
    {
        Transform tr = GetPool_object();
        if (tr == null) return; // if true, this indicates that poolSize is too small..
        Vector3 posit = Vector3.zero;
        posit.x = (immediate_spawnPosition.x * Camera.main.aspect)/target_aspect;
        posit.y = Random.Range(yspawn_Range.min, yspawn_Range.max);
        tr.position = posit;
        Spawn();
    }

    void Shifting()
    {
        for(int i=0; i < pool_objects.Length; i++)
        {
            pool_objects[i].transform.position += -Vector3.right * shift_speed * Time.deltaTime;
            CheckObjectDisposal(pool_objects[i]);
        }
    }

    void CheckObjectDisposal(PObject pool_object)
    {
        if(pool_object.transform.position.x < (-default_spawnPosition.x *Camera.main.aspect)/target_aspect)
        {
            pool_object.dispose();
            pool_object.transform.position = Vector3.one * 1000;
        }
    }

    Transform GetPool_object()
    {
        
        for (int i = 0; i < pool_objects.Length; i++)
        {
            if (!pool_objects[i].inUse)
            {
                pool_objects[i].use();
                return pool_objects[i].transform ;
            }
        }
        return null;
    }
}
