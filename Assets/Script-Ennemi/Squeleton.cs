using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squeleton : AEnemy
{
    // Start is called before the first frame update
    public override void Move()
    {
        if (target)
        {
            Vector3 dir = target.transform.position - transform.position;

            Vector2 direction = new Vector2(dir.x, dir.y).normalized;
            transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * speedCurrent;
            
        }
        SetTarget();
    }

    private void Update()
    {
        
        Move();
        spriteRenderer.flipX = target.transform.position.x < transform.position.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStats>().Damage(damageCurrent);
        }

   
    }
}
