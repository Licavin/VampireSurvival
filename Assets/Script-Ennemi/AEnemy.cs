using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AEnemy : MonoBehaviour
{
    [SerializeField]
    protected float hpMax;
    protected float hpCurrent;
    

    [SerializeField]
    protected float speedDefault;
    protected float speedCurrent;
    

    [SerializeField]
    protected float damageDefault;
    protected float damageCurrent;
    

    [SerializeField]
    protected GameObject target;

    private BoxCollider2D col;
    protected SpriteRenderer spriteRenderer;

    [SerializeField]
    protected UnityEvent onDeath, onDamage, onCollision;
    private void Awake()
    {
        col =GetComponent<BoxCollider2D>();
        spriteRenderer =GetComponent<SpriteRenderer>();
        hpCurrent = hpMax;
        speedCurrent = speedDefault;
        damageCurrent = damageDefault; 

    }

    public virtual void SetTarget(GameObject target)
    {

    }
    public virtual void Move()
    {

    }

    public virtual void OnDeath()
    {
        onDeath.Invoke();
    }

    public virtual void OnDamage()
    {
        onDamage.Invoke();
    }
}
