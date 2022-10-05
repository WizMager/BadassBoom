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
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject namePanel;
        [SerializeField] private GameObject ipPanel;
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
                connectButton.onClick.AddListener(OnConnectHandler);
        }

        private void OnClientStartHandler()
        {
                startPanel.SetActive(false);
                namePanel.SetActive(true);
        }

        private void OnServerStartHandler()
        {
                startPanel.SetActive(false); 
                networkManager.StartServer();
        }

        private void SetName(string playerName)
        {
                _playerName = playerName;
                if (string.IsNullOrWhiteSpace(_playerName)) return;
                namePanel.SetActive(false);
                ipPanel.SetActive(true);
                nameText.text = $"Hello {_playerName}!";
        }

        private void SetIp(string ip)
        {
                _ip = ip;
                connectButton.interactable = !string.IsNullOrWhiteSpace(_ip);
        }
        
        private void OnConnectHandler()
        {
                networkManager.networkAddress = _ip;
                networkManager.StartClient();  
        }

        private void OnDestroy()
        {
                nameInputField.onEndEdit.RemoveListener(SetName);
                ipInputField.onEndEdit.RemoveListener(SetIp);
                startServer.onClick.RemoveListener(OnServerStartHandler);
                startClient.onClick.RemoveListener(OnClientStartHandler);
                connectButton.onClick.RemoveListener(OnConnectHandler);    
        }
}