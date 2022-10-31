using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Scee

public class CharacterSelection : MonoBehaviour
{




    public GameObject P11;
    public GameObject P12;
    public GameObject P13;
    public GameObject P14;
    
    public GameObject P21;
    public GameObject P22;
    public GameObject P23;
    public GameObject P24;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void P11Clicked()
    {
        P11.SetActive(true);
        P12.SetActive(false);
        P13.SetActive(false);
        P14.SetActive(false);
    }
    
    public void P12Clicked()
    {
        P11.SetActive(false);
        P12.SetActive(true);
        P13.SetActive(false);
        P14.SetActive(false);
    }
    
    public void P13Clicked()
    {
        P11.SetActive(false);
        P12.SetActive(false);
        P13.SetActive(true);
        P14.SetActive(false);
    }
    
    public void P14Clicked()
    {
        P11.SetActive(false);
        P12.SetActive(false);
        P13.SetActive(false);
        P14.SetActive(true);
    }



    public void P21Clicked()
    {
        P21.SetActive(true);
        P22.SetActive(false);
        P23.SetActive(false);
        P24.SetActive(false);
    }

    public void P22Clicked()
    {
        P21.SetActive(false);
        P22.SetActive(true);
        P23.SetActive(false);
        P24.SetActive(false);
    }

    public void P23Clicked()
    {
        P21.SetActive(false);
        P22.SetActive(false);
        P23.SetActive(true);
        P24.SetActive(false);
    }

    public void P24Clicked()
    {
        P21.SetActive(false);
        P22.SetActive(false);
        P23.SetActive(false);
        P24.SetActive(true);
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }
}
