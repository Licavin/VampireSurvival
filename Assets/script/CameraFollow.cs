using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;
    private Camera camCurrent;
    bool initCam =false;
    private Vector3 velocity;
    private void Start()
    {
          camCurrent = GetComponent<Camera>();
    }
    void Update()
    {
        if (player != null)
        {

            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        }        
    }
}
