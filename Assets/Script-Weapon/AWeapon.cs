using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AWeapon : MonoBehaviour
{
    [SerializeField]
    protected LevelWeapon levelWeapon;

    [SerializeField]
    protected float damageDefault;
    protected float damageCurrent;

    [SerializeField]
    protected float speedDefault;
    protected float speedCurrent;

    [SerializeField]
    protected float lifetimeDefault;
    protected float lifetimeCurrent;

    [SerializeField]
    protected int numberProjectileDefault;
    protected int numberProjectileCurrent;

    [SerializeField]
    protected float reloadTimeDefault;
    protected float reloadTimeCurrent;

    [SerializeField]
    protected float sizeDefault;
    protected float sizeCurrent;

    public virtual void Init()  
    {
        damageCurrent = damageDefault;
        speedCurrent = speedDefault;
        lifetimeCurrent = lifetimeDefault;
        numberProjectileCurrent = numberProjectileDefault;
        reloadTimeCurrent =reloadTimeDefault;
        sizeCurrent = sizeDefault;
    }

}

[System.Serializable]
public class LevelWeapon
{
    public int levelcurrent;
    public int levelMax;
    public List<UnityEvent> unityEvents;

    public void LevelUp()
    {
        if (levelcurrent<levelMax)
        {
            unityEvents[levelcurrent].Invoke();
        }
        levelcurrent++;

    }
}