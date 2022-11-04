using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private Button startServeurButton;
    [SerializeField]
    private Button startHostButton;
    [SerializeField]
    private Button startClientButton;

    [SerializeField]
    private TextMeshProUGUI PlayersInGameText;

    [SerializeField]
    private Text inputFieldAddres;

    public UnityTransport untp;  //find UnityTransport data address
    public GetIpV4 gip;  //find me ipv4
    
    public GameObject inGameMenu;
    public MenuScrip menuScript;
    public GameObject ipCanvas;

    private void Awake()
    {
        Cursor.visible = true;
    }

    private void Update()
    {
        //PlayersInGameText.text = $"Players in game: {PlayersManager.Instance.PlayersInGame}";
    }


    private void Start()
    {


        startHostButton.onClick.AddListener(() =>
        {
            untp.ConnectionData.Address = gip.GetLocalIPAddress();//get me ip for host game 
            Debug.Log(untp.ConnectionData.Address);
            if (NetworkManager.Singleton.StartHost())
            {
                Debug.Log("Host started..."); //StartHost
                //inGameMenu.SetActive(true);
            }
            else
            {
                Debug.Log("Host STOPted...");
            }
        });
        startServeurButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartServer())
            {

            }
            else
            {

            }
        });

        startClientButton.onClick.AddListener(() =>
        {
           
            if (NetworkManager.Singleton.StartClient())
            {
                //GameManager.Instance.PlayerJoin();
                Debug.Log("client started...");//Start join
                //inGameMenu.SetActive(true);
                menuScript.MenuCanvas.SetActive(false);
                menuScript.joinIPPanel.SetActive(false);
                menuScript.ipCanvas.SetActive(false);

            }
            else
            {
                Debug.Log("client stopted...");
            }
        });
    }

    public void inputAddres()
    {
        untp.ConnectionData.Address = inputFieldAddres.text;
        Debug.Log(inputFieldAddres.text);
        Debug.Log(untp.ConnectionData.Address);
    }
}
