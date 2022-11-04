using System.Collections;
using UnityEngine;

public class PlayerShot : AWeapon
{
    public GameObject projectile;
    public GameObject spawnPoint;

    private float delay;
    public float TimeBetweenShots = 0.5f;  // seconds
    float reloadTimer;
    // Start is called before the first frame update
    public AudioSource audio;
    private void Awake()
    {
        Init();
        reloadTimer = reloadTimeCurrent;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
                reloadTimer = reloadTimeCurrent;
                //levelWeapon.LevelUp();
                StartCoroutine(Salva());
            }
        }



    }
    IEnumerator Salva()
    {

        GameObject proj;
        for (int i = 0; i < numberProjectileCurrent; i++)
        {
            audio.Play();
            proj = Instantiate(projectile, spawnPoint.transform.position, Quaternion.identity);
            proj.GetComponent<ProjectileMove>().Init(lifetimeCurrent, damageCurrent, sizeCurrent, speedCurrent);
            yield return new WaitForSeconds(0.1f);
        }



        
    }

    public void AddProjectile()
    {
        numberProjectileCurrent++;
        
        

    }

    public void AddDamage()
    {
        damageCurrent *= 1.5f;

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

    }
}