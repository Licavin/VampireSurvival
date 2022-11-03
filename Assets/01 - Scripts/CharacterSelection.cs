using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterSelection : MonoBehaviour
{
    public List<GameObject> Player1 = new List<GameObject>();
    public List<GameObject> Player2 = new List<GameObject>();

    public List<GameObject> SelectionOverlay = new List<GameObject>();


    public void P1Apparence1Clicked()
    {
        SelectionOverlay[0].SetActive(true);
        SelectionOverlay[1].SetActive(false);
        Player1[0].SetActive(true);
        Player1[1].SetActive(false);
    }

    public void P1Apparence2Clicked()
    {
        SelectionOverlay[0].SetActive(false);
        SelectionOverlay[1].SetActive(true);
        Player1[0].SetActive(false);
        Player1[1].SetActive(true);
    }

    public void P2Apparence1Clicked()
    {
        SelectionOverlay[2].SetActive(true);
        SelectionOverlay[3].SetActive(false);
        Player2[0].SetActive(true);
        Player2[1].SetActive(false);
    }

    public void P2Apparence2Clicked()
    {
        SelectionOverlay[2].SetActive(false);
        SelectionOverlay[3].SetActive(true);
        Player2[0].SetActive(false);
        Player2[1].SetActive(true);
    }

    public void LaunchGame()
    {
        //SceneManager.LoadScene(X);
    }
}