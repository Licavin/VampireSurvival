using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Camera camera;
    private Transform cameraTransform;
    
    
    
    private int currentEnemy;
    private float BeginTime;
    private float lastTimeSpawn;

    private int i = 0;
    public List<RoundEnemies> rounds;

    private float orthoSize=15;
    private void Awake()
    {
        camera = Camera.main;
        cameraTransform = camera.gameObject.transform;
        camera.orthographicSize = orthoSize;
        BeginTime = Time.time;
        lastTimeSpawn = Time.time;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        spawnTimer = spawnTimerBase;
    }

    float spawnTimerBase = 2;
    float spawnTimer;
    
    // Update is called once per frame
    void Update()
    {
        if(spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            if(spawnTimer < 0)
            {
                spawnTimer += spawnTimerBase;
                Spawn();
            }
        }

        if (Time.time-BeginTime > rounds[i].endTimerRound && i!= rounds.Count -1)
        {
            i++;
        }
 
    }

    private void Spawn()
    {
       GameObject nextEnemy = rounds[i].enemies[ Random.Range(0, rounds[i].enemies.Count )];
       float dirX = Random.Range(-1,1);
       float dirY = Random.Range(-1, 1);
       float radius = Random.Range (2.1f * orthoSize , 3.5f* orthoSize);
       Vector3 pos = new Vector3(dirX, dirY, 0).normalized*radius+cameraTransform.position;


       lastTimeSpawn = Time.time;
       Instantiate(nextEnemy,pos, Quaternion.identity);
    }
        
}

[System.Serializable]
public class RoundEnemies
{
    public List<GameObject> enemies;
    public float spawnCD;
    public float endTimerRound;
    public int maxEnemy;
}
