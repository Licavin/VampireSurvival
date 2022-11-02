using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScrip : MonoBehaviour
{
    public GameObject joinIPPanel;
    public GameObject hostIPPanel;




    public void JoinIP()
    {
        hostIPPanel.SetActive(false);
        joinIPPanel.SetActive(true);
    }

    public void HostIP()
    {
        hostIPPanel.SetActive(true);
        joinIPPanel.SetActive(false);
    }

    public void IPnextStep()
    {
        Debug.Log("continue");
    }
}
