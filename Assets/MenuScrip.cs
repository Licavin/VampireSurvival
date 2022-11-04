using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScrip : MonoBehaviour
{
    public GameObject joinIPPanel;
    public GameObject hostIPPanel;
    public GameObject characterCanvas;
    public GameObject ipCanvas;
    public GameObject MenuCanvas;
    public GameObject ErrorCanvas;
    public GameObject hostIpShow;
    public GameObject lostCanvas;

    bool host;
    bool join;
    bool wrongIP;


    public void Update()
    {
        if(wrongIP == true)
        {
            ErrorCanvas.SetActive(true);
        }
        else
        {
            ErrorCanvas.SetActive(false);
        }
    }
    public void JoinIP()
    {
        join = true;
        ipCanvas.SetActive(true);
        hostIPPanel.SetActive(false);
        joinIPPanel.SetActive(true);
    }

    public void HostIP()
    {
        StartCoroutine(IpShow());
        host = true;
        ipCanvas.SetActive(true);
        hostIPPanel.SetActive(true);
        joinIPPanel.SetActive(false);
    }

    public void LaunchGame()
    {
        characterCanvas.SetActive(false);
        ipCanvas.SetActive(false);
        joinIPPanel.SetActive(false);
        MenuCanvas.SetActive(false);
        Debug.Log("continue");
    }

    public void Return()
    {
        //MenuCanvas.SetActive(true);
        ipCanvas.SetActive(false);
    }

    IEnumerator IpShow()
    {
        hostIpShow.SetActive(true);
        yield return new WaitForSeconds(15);
        hostIpShow.SetActive(false);
    }

    public void defaite()
    {
        lostCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
