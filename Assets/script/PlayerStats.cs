using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update

    public float healthMax;
    private float healthCurrent;

    public float speedDefault;
    private float speedCurent;

    public float currentExp;
    private float nextXP;
    private float currentLevel;

    private void Awake()
    {
        healthCurrent = healthMax;
        speedCurent = speedDefault;
        currentExp = 0;
        currentLevel = 1;
        NextXp(1);
    }


    public  void Damage(float dmg)
    {
        healthCurrent -= dmg;
        if (healthCurrent<=0)
        {
            Death();
        }

    }

    private void Death()
    {

    }

    public void AddHealth(float value)
    {
        healthCurrent = Mathf.Clamp(healthCurrent + value, 0, healthMax);
    }
    private void NextXp(float n)
    {
        nextXP = 50*Mathf.Pow(2,Mathf.Pow(2,Mathf.Log(n)));
    }

    public void AddExp(float value)
    {
        currentExp += value;
        if (currentExp>nextXP)
        {
            LevelUp();
            currentLevel++;
            currentExp = 0;
            NextXp(currentLevel);
        }
    }

    public void LevelUp()
    {

    }
}
