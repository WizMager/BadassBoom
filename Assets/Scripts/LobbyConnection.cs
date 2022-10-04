using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyConnection : MonoBehaviour
{
        [SerializeField] private NetworkManager networkManager;
        [SerializeField] private TMP_InputField ipInputField;
        [SerializeField] private Button startServer;
        [SerializeField] private Button startClient;
        [SerializeField] private TMP_InputField nameInputField;
        [SerializeField] private Button connectButton;
        [SerializeField] private TMP_Text nameText;
        private string _playerName;
        private string _ip;

        public string GetPlayerName => _playerName;
        public string GetIp => _ip;

        private void Start()
        {
                connectButton.interactable = false;
                nameInputField.onEndEdit.AddListener(SetName);
                ipInputField.onEndEdit.AddListener(SetIp);
                startServer.onClick.AddListener(OnServerStartHandler);
                startClient.onClick.AddListener(OnClientStartHandler);
        }

        private void OnClientStartHandler()
        {
                connectButton.gameObject.SetActive(true);
                nameInputField.gameObject.SetActive(true);
                startClient.gameObject.SetActive(false);
                startServer.gameObject.SetActive(false);
        }

        private void OnServerStartHandler()
        {
                networkManager.StartServer();
                startClient.gameObject.SetActive(false);
                startServer.gameObject.SetActive(false);   
        }

        private void SetName(string playerName)
        {
                _playerName = playerName;
                if (string.IsNullOrWhiteSpace(_playerName)) return;
                nameText.gameObject.SetActive(true);
                nameText.text = $"Hello {_playerName}!";
                nameInputField.gameObject.SetActive(false);
                ipInputField.gameObject.SetActive(true);
        }

        private void SetIp(string ip)
        {
                _ip = ip;
                connectButton.interactable = !string.IsNullOrWhiteSpace(_ip);
        }
}