using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    private Transform cameraTransform;
    
    
    
    private int currentEnemy;
    

    private int i = 0;
    public List<RoundEnemies> rounds;

    float spawnTimerBase = 2;
    float spawnTimer;
    float roundTimer;
    private float orthoSize=5;

    private static EnemyManager instance = null;
    public static EnemyManager Instance => instance;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        
       
            
    }
    // Start is called before the first frame update
    void Start()
    {
        
        spawnTimer = spawnTimerBase;
        roundTimer = rounds[i].timerRound;

    }


    
    // Update is called once per frame
    void Update()
    {
        if (player)
        {


            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
                if (spawnTimer < 0)
                {
                    spawnTimer = rounds[i].spawnCD;
                    if (currentEnemy < rounds[i].maxEnemy)
                    {
                        Spawn();
                        currentEnemy++;
                    }

                }
            }



            if (roundTimer > 0)
            {
                roundTimer -= Time.deltaTime;
                if (roundTimer < 0)
                {
                    i++;
                    if (i <= rounds.Count)
                    {
                        roundTimer = rounds[i].timerRound;

                    }

                }
            }
        }
    }

    private void Spawn()
    {
    
           GameObject nextEnemy = rounds[i].enemies[ Random.Range(0, rounds[i].enemies.Count )];
           float dirX = Random.Range(-1f,1f);
           float dirY = Random.Range(-1f, 1f);
           float radius = Random.Range (2.1f * orthoSize , 3.5f* orthoSize);
           Vector3 pos = new Vector3(dirX, dirY, 0).normalized*radius+player.transform.position + new Vector3(0,0,10);
           Instantiate(nextEnemy, pos, Quaternion.identity);
        



       
       
    }
        
}

[System.Serializable]
public class RoundEnemies
{
    public List<GameObject> enemies;
    public float spawnCD;
    public float timerRound;
    public int maxEnemy;
}
