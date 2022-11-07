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

    [SerializeField]
    protected Color damageColor, baseColor;

    [SerializeField]
    protected float colorSpeed;

    [SerializeField]
    protected GameObject Drop;

    [SerializeField]
    protected GameObject spawnPointGemme;

<<<<<<< HEAD
    [SerializeField]
    UnityEvent playAudio;

=======
>>>>>>> parent of cd739a6 (Merge branch 'main' of https://github.com/Licavin/VampireSurvival)
    private void Awake()
    {
        col =GetComponent<BoxCollider2D>();
        spriteRenderer =GetComponent<SpriteRenderer>();
        hpCurrent = hpMax;
        speedCurrent = speedDefault;
        damageCurrent = damageDefault; 
        spriteRenderer.material.color = baseColor;
    }

    public virtual void SetTarget()
    {
        GameObject tempTarget = this.gameObject;
        float minDist = float.MaxValue;

        PlayerStats[] players = FindObjectsOfType<PlayerStats>();
        foreach (PlayerStats player in players)
        {
            float dist = (transform.position - player.transform.position).magnitude;
            if (dist<minDist)
            {
                minDist = dist;
                tempTarget = player.gameObject;
            }
        }
        target = tempTarget;
    }
    public virtual void Move()
    {

    }
    public void Damage(float damage)
    {
<<<<<<< HEAD
        playAudio.Invoke();
=======
        
>>>>>>> parent of cd739a6 (Merge branch 'main' of https://github.com/Licavin/VampireSurvival)
        hpCurrent -= damage;
        StartCoroutine(DamageVisual());
        if (hpCurrent<=0)
        {
            OnDeath();
        }
    }

    public virtual void OnDeath()
    {
        StopCoroutine(DamageVisual());
        onDeath.Invoke();
        Instantiate(Drop, spawnPointGemme.transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }



    public virtual void OnDamage()
    {
        onDamage.Invoke();
    }

    IEnumerator DamageVisual()
    {
        float t = 0;
        Color color;
        while (t<1)
        {
            
            t += Time.deltaTime*colorSpeed;
            color = Color.Lerp(baseColor, damageColor, t);
            spriteRenderer.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        while (t > 0)
        {
            t -= Time.deltaTime * colorSpeed;
            color = Color.Lerp(baseColor, damageColor, t);
            spriteRenderer.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        
    }
}
