using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterSelection : MonoBehaviour
{
    public List<GameObject> Player1 = new List<GameObject>();
    public List<GameObject> Player2 = new List<GameObject>();

    public void P1Apparence1Clicked()
    {
        Player1[0].SetActive(true);
        Player1[1].SetActive(false);
        Player1[2].SetActive(false);
        Player1[3].SetActive(false);
    }

    public void P1Apparence2Clicked()
    {
        Player1[0].SetActive(false);
        Player1[1].SetActive(true);
        Player1[2].SetActive(false);
        Player1[3].SetActive(false);
    }

    public void P1Apparence3Clicked()
    {
        Player1[0].SetActive(false);
        Player1[1].SetActive(false);
        Player1[2].SetActive(true);
        Player1[3].SetActive(false);
    }

    public void P1Apparence4Clicked()
    {
        Player1[0].SetActive(false);
        Player1[1].SetActive(false);
        Player1[2].SetActive(false);
        Player1[3].SetActive(true);
    }



    public void P2Apparence1Clicked()
    {
        Player2[0].SetActive(true);
        Player2[1].SetActive(false);
        Player2[2].SetActive(false);
        Player2[3].SetActive(false);
    }

    public void P2Apparence2Clicked()
    {
        Player2[0].SetActive(false);
        Player2[1].SetActive(true);
        Player2[2].SetActive(false);
        Player2[3].SetActive(false);
    }

    public void P2Apparence3Clicked()
    {
        Player2[0].SetActive(false);
        Player2[1].SetActive(false);
        Player2[2].SetActive(true);
        Player2[3].SetActive(false);
    }

    public void P2Apparence4Clicked()
    {
        Player2[0].SetActive(false);
        Player2[1].SetActive(false);
        Player2[2].SetActive(false);
        Player2[3].SetActive(true);
    }

    public void LaunchGame()
    {
        //SceneManager.LoadScene(X);
    }
}