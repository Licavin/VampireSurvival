using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void Update()
    {
        
    }


    IEnumerator LaunchGame()
    {
        Debug.Log("go");
        yield return new WaitForSeconds(1f);
        //SceneManager.LoadScene(X);
        Debug.Log("gogo");
    }

    public void Launch()
    {
        StartCoroutine(LaunchGame());
    }

    public void SetProfile()
    {
        //SceneManager.LoadScene(X);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
