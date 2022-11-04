using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update

    public float healthMaxDefault;
    private float healthMaxCurrent;
    private float healthCurrent;

    public float speedDefault;
    private float speedCurent;

    public float currentExp;
    private float nextXP;
    private float currentLevel;

    private float Timer;

    public GameObject panel;

    
    public TMP_Text text;
    public Scrollbar scrollbarExp;
    public Scrollbar scrollbarLife;
    private void Awake()
    {
        Timer = 0;
        healthMaxCurrent = healthMaxDefault;
        healthCurrent = healthMaxDefault;
        speedCurent = speedDefault;
        currentExp = 0;
        currentLevel = 1;
        NextXp(1);
    }

    private void Update()
    {
        Timer+=Time.deltaTime;
        scrollbarExp.size = Mathf.Clamp01( currentExp/nextXP);
        scrollbarLife.size = Mathf.Clamp01( healthCurrent/healthMaxDefault);
        text.text = $"SurvivedTime: {Mathf.Floor(Timer)}";
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

    public void Heal()
    {
        healthCurrent = healthMaxDefault;
    }

    public void AddHealth(float value)
    {
        healthCurrent = Mathf.Clamp(healthCurrent + value, 0, healthMaxCurrent);
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

        panel.SetActive(true);
    }
}
