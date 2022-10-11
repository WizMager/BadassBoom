using System.Collections.Generic;
using ComponentViews;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text menuTitleText;
    [SerializeField] private Button createRoomButton;
    [SerializeField] private Button loginButton;
    [SerializeField] private TMP_InputField textInputField;
    [SerializeField] private Button exitButton;
    [SerializeField] private RectTransform roomContainer;
    [SerializeField] private GameObject roomButtonPrefab;
    [SerializeField] private float heightRoomButtonsAndSpaceBetweenIts = 100f;
    private readonly List<RoomButtonComponents> _roomButtons = new List<RoomButtonComponents>();

    private void Start()
    {
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
        createRoomButton.onClick.AddListener(OnCreateRoomHandler);
        loginButton.onClick.AddListener(OnLoginHandler);
        exitButton.onClick.AddListener(OnExitHandler);
        createRoomButton.gameObject.SetActive(false);
        textInputField.interactable = false;
        loginButton.interactable = false;
    }

    public override void OnConnectedToMaster()
    {
        textInputField.interactable = true;
        loginButton.interactable = true;
    }

    private void OnCreateRoomHandler()
    {
        var roomName = textInputField.text;
        if (roomName.Length < 3 || roomName.Length > 10) return;
        textInputField.interactable = false;
        createRoomButton.interactable = false;
        PhotonNetwork.CreateRoom(roomName, new RoomOptions{MaxPlayers = 4});
    }

    public override void OnCreatedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        textInputField.interactable = true;
        createRoomButton.interactable = true;
    }

    private void OnLoginHandler()
    {
        var nickname = textInputField.text;
        if (nickname.Length < 3 || nickname.Length > 10) return;
        PhotonNetwork.NickName = nickname;
        loginButton.gameObject.SetActive(false);
        createRoomButton.gameObject.SetActive(true);
        menuTitleText.text = $"Hello {nickname}!";
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (var roomButton in _roomButtons)
        {
            Destroy(roomButton.gameObject);
        }
        _roomButtons.Clear();
        var containerDeltaSize = roomContainer.sizeDelta;
        containerDeltaSize.y = roomList.Count * heightRoomButtonsAndSpaceBetweenIts;
        if (roomContainer.sizeDelta != containerDeltaSize)
        {
            roomContainer.sizeDelta = containerDeltaSize; 
        }
        for (int i = 0; i < roomList.Count; i++)
        {
            var roomButton = Instantiate(roomButtonPrefab, roomContainer).GetComponent<RoomButtonComponents>();
            _roomButtons.Add(roomButton);
            var buttonText = roomButton.GetButtonText;
            buttonText.text = roomList[i].Name;
            roomButton.OnRoomClick += OnRoomClickHandler;
        }
    }

    private void OnRoomClickHandler(string id, RoomButtonComponents roomButton)
    {
        roomButton.OnRoomClick -= OnRoomClickHandler;
        if (PhotonNetwork.LocalPlayer.UserId != id) return;
        PhotonNetwork.JoinRoom(roomButton.GetButtonText.text);
    }

    private void OnExitHandler()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        createRoomButton.onClick.RemoveListener(OnCreateRoomHandler);
        loginButton.onClick.RemoveListener(OnLoginHandler);
        exitButton.onClick.RemoveListener(OnExitHandler);
    }
}