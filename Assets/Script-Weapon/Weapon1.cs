using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon1 : AWeapon
{

    [SerializeField]
    protected GameObject projectile;

    public List<GameObject> currentProjectiles;
    private float reloadTimer;
    private float lifetimeTimer;

    public float range;
    private void Awake()
    {
        Init();
        reloadTimer = reloadTimeCurrent;
        //lifetimeTimer = lifetimeCurrent;
    }

    private void Start()
    {
        for (int i = 0; i < numberProjectileCurrent; i++)
        {
            GameObject proj = Instantiate(projectile, transform.parent);
            currentProjectiles.Add(proj);
        }
        foreach (GameObject proj in currentProjectiles)
        {
            proj.GetComponent<Projectile1>().UpdateDamage(damageCurrent);
        }
    }
    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (reloadTimer > 0)
        {
            reloadTimer -= Time.deltaTime;
            if (reloadTimer < 0)
            {
                lifetimeTimer = lifetimeCurrent;
                levelWeapon.LevelUp();
                foreach (var proj in currentProjectiles)
                {
                    proj.SetActive(true);
                    
                }
                
                    
                
                    
                    

                

            }
        }



        if (lifetimeTimer > 0)
        {
            lifetimeTimer -= Time.deltaTime;
            for (int i = 0; i < currentProjectiles.Count; i++)
            {
                currentProjectiles[i].transform.position = transform.position+ new Vector3( Mathf.Cos(Mathf.PI *2* i / numberProjectileCurrent+ Time.time*speedCurrent),
                                                                        Mathf.Sin(Mathf.PI *2* i / numberProjectileCurrent + Time.time*speedCurrent), 0)*range;
            }

            if (lifetimeTimer < 0)
            {
                reloadTimer = reloadTimeCurrent;
                foreach ( GameObject proj in currentProjectiles)
                {
                    proj.SetActive(false);
                }

            }
        }
    }

    public void AddProjectile()
    {
        numberProjectileCurrent++;
        GameObject go = Instantiate(projectile, transform.parent);
        currentProjectiles.Add(go);
        
    }

    public void AddDamage()
    {
        damageCurrent*=1.5f;
        foreach (GameObject proj in currentProjectiles)
        {
            Projectile1 script = proj.GetComponent<Projectile1>();
            script.UpdateDamage(damageCurrent);
        }

    }

    public void AddSpeed()
    {
        speedCurrent *= 1.2f;
    }

    public void AddLifetime()
    {
        lifetimeCurrent *= 1.2f;
    }

    public void DecreaseReload()
    {
        reloadTimeCurrent *= 0.8f;
    }

    public void AddSize()
    {
        sizeCurrent *= 1.2f;
        foreach (GameObject proj in currentProjectiles)
        {
            Projectile1 script = proj.GetComponent<Projectile1>();
            script.UpdateSize(sizeCurrent);
        }

    }
}
