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
        hostIPPanel.SetActive(false);
        joinIPPanel.SetActive(true);
    }

    public void HostIP()
    {
        host = true;
        hostIPPanel.SetActive(true);
        joinIPPanel.SetActive(false);
    }

    public void IPnextStep()
    {
        characterCanvas.SetActive(true);
        ipCanvas.SetActive(false);
        Debug.Log("continue");
    }
}
