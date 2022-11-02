using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile1 : MonoBehaviour
{
    CircleCollider2D circleCollider;

    private float damage;
    private float size=.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        transform.localScale = Vector3.one * size;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemy"))
        {
            
            collision.gameObject.GetComponent<AEnemy>().Damage(damage);
        }
            
    }
    // Update is called once per frame


    public void UpdateDamage(float newDamage)
    {
        damage = newDamage;
    }

    public void UpdateSize(float newSize)
    {
        size=newSize;
        transform.localScale = Vector3.one * size;
    }
}
