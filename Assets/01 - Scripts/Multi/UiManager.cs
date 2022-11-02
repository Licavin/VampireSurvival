using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

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

    private void Awake()
    {
        Cursor.visible = true;
    }

    private void Update()
    {
        //PlayersInGameText.text = $"Players in game: {PlayersManager.instance.PlayersInGame}";
    }


    private void Start()
    {
        startHostButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartHost())
            {
                //Debug.Log(Instance.LogInfo("Host started..."));
            }
            else
            {

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

            }
            else
            {

            }
        });
    }
}
