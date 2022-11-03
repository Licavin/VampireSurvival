using System;
using Unity.Netcode;
using UnityEngine;
using Unity.Mathematics;
using Random = UnityEngine.Random;

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

        Camera[] cams = FindObjectsOfType<Camera>();

        foreach (Camera cam in cams)
        {
            if (cam.name == currentCam.name)
            {
                cam.enabled = true;
            }
            else
            {
                cam.enabled = false;
            }
        }

        
        /*if (FindObjectOfType<Camera>().GetComponent<CameraFollow>().player == null)//for add camera follow
        {
            FindObjectOfType<Camera>().GetComponent<CameraFollow>().player = this.gameObject;
            FindObjectOfType<Camera>().transform.parent = this.gameObject.transform;
        }
        else// Add new camera for player two 
        {
            GameObject cam;
            cam = Instantiate(GameManager.Instance.prefabsCameraFollow, new Vector3(0, 0, 0), Quaternion.identity);    
            if (cam.GetComponent<CameraFollow>().player == null)//for add camera follow
            {
                cam.GetComponent<CameraFollow>().player = this.gameObject;     
            }
        }*/
        
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
