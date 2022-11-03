using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

public class ProjectileMove : MonoBehaviour
{

    private GameObject target;
    private float lifeTime;
    private float damage;
    private float size;
    private float speed;
    private Vector3 dir;
    Collider2D coll;
    Transform myTransform;
   

    // Start is called before the first frame update
    void Start()
    {

        //myTransform = GetComponent<Transform>();

        coll = GetComponent<Collider2D>();
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
        
        dir = (target.transform.position - transform.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += dir* speed*Time.deltaTime;
        transform.up = dir;



        Destroy(this.gameObject, lifeTime);
    }

    public void Init(float lifeT, float dmg, float siz, float spd)
    {
        lifeTime = lifeT;
        damage = dmg;
        size = siz;
        speed = spd;

        transform.localScale = Vector3.one * size;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("collision enemy");
            collision.gameObject.GetComponent<AEnemy>().Damage(damage);
            Destroy(this.gameObject);
        }
    }
   
}
