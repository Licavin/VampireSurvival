using UnityEngine;

public class PlayerShot : AWeapon
{
    public GameObject projectile;
    public GameObject spawnPoint;

    private float delay;
    public float TimeBetweenShots = 0.5f;  // seconds
    float reloadTimer;
    // Start is called before the first frame update

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
        GameObject proj;
        if (reloadTimer > 0)
        {
            reloadTimer -= Time.deltaTime;
            if (reloadTimer < 0)
            {
                reloadTimer = reloadTimeCurrent;
                //levelWeapon.LevelUp();
                proj = Instantiate(projectile, spawnPoint.transform.position, Quaternion.identity);
                proj.GetComponent<ProjectileMove>().Init(lifetimeCurrent, damageCurrent, sizeCurrent, speedCurrent);
            }
        }



    }

}