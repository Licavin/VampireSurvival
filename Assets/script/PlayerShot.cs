using UnityEngine;

public class PlayerShot : AWeapon
{
    public GameObject projectile;
    public GameObject spawnPoint;

    private float delay;
    public float TimeBetweenShots = 0.5f;  // seconds

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }

        // can we shoot yet?
        if (delay <= 0)
        {
            
            delay = TimeBetweenShots;

            Instantiate(projectile, spawnPoint.transform.position, Quaternion.identity);
        }

    }


}