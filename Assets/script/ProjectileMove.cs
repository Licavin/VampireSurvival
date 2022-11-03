using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ProjectileMove : MonoBehaviour
{

    [SerializeField] private GameObject target;
    public float speed = 1.5f;

    Transform myTransform;
   

    // Start is called before the first frame update
    void Start()
    {

        //myTransform = GetComponent<Transform>();

        
        var enemies = FindObjectsOfType<AEnemy>();
        float minDist = float.MaxValue;
        GameObject closestEnemy = this.gameObject;
        foreach (var enemy in enemies)
        {
            if ((enemy.transform.position - transform.position).magnitude < minDist)
            {
                minDist = enemy.transform.position.magnitude;
                closestEnemy = enemy.gameObject;
            }
        }

        target = closestEnemy;
        target.transform.position = closestEnemy.transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.up = target.transform.position - transform.position;



        Destroy(this.gameObject, 3f);
    }
}
