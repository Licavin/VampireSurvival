using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squeleton : AEnemy
{
    // Start is called before the first frame update
    public override void Move()
    {
        Vector3 dir = target.transform.position-transform.position;
        
        Vector2 direction = new Vector2(dir.x, dir.y).normalized;
        transform.position += dir*Time.deltaTime*speedCurrent;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.SetActive(false);
        }

   
    }
}
