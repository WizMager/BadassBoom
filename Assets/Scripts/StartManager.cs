using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Button createGameButton;
    [SerializeField] private TMP_InputField nicknameInputField;
    [SerializeField] private Button joinGameButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
        createGameButton.onClick.AddListener(OnCreateGameHandler);
        nicknameInputField.onEndEdit.AddListener(OnInputNicknameHandler);
        joinGameButton.onClick.AddListener(OnJoinGameHandler);
        exitButton.onClick.AddListener(OnExitHandler);
        nicknameInputField.interactable = false;
        createGameButton.interactable = false;
        joinGameButton.interactable = false;
    }

    public override void OnConnectedToMaster()
    {
        nicknameInputField.interactable = true;
    }

    private void OnCreateGameHandler()
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = 4});
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        nicknameInputField.interactable = true;
        createGameButton.interactable = false;
        joinGameButton.interactable = false;
    }

    private void OnInputNicknameHandler(string nickname)
    {
        var nicknameLength = nickname.Length;
        if (nicknameLength < 3 || nicknameLength > 10) return;
        PhotonNetwork.NickName = nickname;
        nicknameInputField.interactable = false;
        createGameButton.interactable = true;
        joinGameButton.interactable = true;
    }
        
    private void OnJoinGameHandler()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        nicknameInputField.interactable = true;
        createGameButton.interactable = false;
        joinGameButton.interactable = false;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        nicknameInputField.interactable = true;
        createGameButton.interactable = false;
        joinGameButton.interactable = false;
    }
    
    private void OnExitHandler()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        createGameButton.onClick.RemoveListener(OnCreateGameHandler);
        nicknameInputField.onEndEdit.RemoveListener(OnInputNicknameHandler);
        joinGameButton.onClick.RemoveListener(OnJoinGameHandler);
        exitButton.onClick.RemoveListener(OnExitHandler);
    }
}