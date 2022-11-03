using System;
using Unity.Netcode;
using UnityEngine;
using Unity.Mathematics;
using Random = UnityEngine.Random;
using Cinemachine;
using UnityEngine.Assertions;

public class PlayerControl : NetworkBehaviour
{
    [SerializeField]
    private float walkSpeed = 3.5f;

    [SerializeField]
    private Vector2 defaultPositionRange = new Vector2(-4, 4);

    [SerializeField]
    private NetworkVariable<float> forwardBackPosition = new NetworkVariable<float>();

    [SerializeField]
    private NetworkVariable<float> leftRightPosition = new NetworkVariable<float>();

    // client caching
    private float oldForwardPosition;
    private float oldleftRightPosition;

    public Animator animator;
    public Camera currentCam;

    private void Start()
    {

        transform.position = new Vector2(Random.Range(defaultPositionRange.x, defaultPositionRange.y),
            Random.Range(defaultPositionRange.x, defaultPositionRange.y));
      
        if (!IsOwner)//delet wrong cam
        {
            currentCam.gameObject.SetActive(false);
        }
        
    }

    private void Update()
    {
        if (IsServer)
        {
            UpdateServeur();
        }

        if (IsClient && IsOwner)
        {        

            UpdateClient();
        }

    }

    private void UpdateServeur()
    {
        transform.position = new Vector2(transform.position.x + leftRightPosition.Value, transform.position.y + forwardBackPosition.Value);
    }

    private void UpdateClient()
    {
        float forwardBackward = 0;
        float leftRight = 0;

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
        {
            forwardBackward += walkSpeed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            forwardBackward -= walkSpeed;
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            leftRight -= walkSpeed;
            //add anim left
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            leftRight += walkSpeed;
            //add anim right
        }

        if (oldForwardPosition != forwardBackward || oldleftRightPosition != leftRight)
        {
            oldForwardPosition = forwardBackward;
            oldleftRightPosition = leftRight;

            // Update the serveur
            UpdateClientPositionServerRpc(forwardBackward, leftRight);
        }
    }   

    [ServerRpc]
    public void UpdateClientPositionServerRpc(float forwardBackward, float leftRight)
    {
        forwardBackPosition.Value = forwardBackward;
        leftRightPosition.Value = leftRight;
    }


}



