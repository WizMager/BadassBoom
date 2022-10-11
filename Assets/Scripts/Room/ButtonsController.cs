using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Room
{
    public class ButtonsController : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Button startGame;
        [SerializeField] private Button leaveRoom;

        private void Start()
        {
            startGame.onClick.AddListener(OnStartGameHandler);
            leaveRoom.onClick.AddListener(OnLeaveRoomHandler);
            if (PhotonNetwork.IsMasterClient) return;
            startGame.gameObject.SetActive(false);
        }

        private void OnStartGameHandler()
        {
            Debug.Log("startGame");
        }

        private void OnLeaveRoomHandler()
        {
            PhotonNetwork.LeaveRoom();
            
        }

        public override void OnLeftRoom()
        {
            //PhotonNetwork.Disconnect();
            SceneManager.LoadScene(0);
        }

        private void OnDestroy()
        {
            startGame.onClick.RemoveListener(OnStartGameHandler);
            leaveRoom.onClick.RemoveListener(OnLeaveRoomHandler);
        }
    }
}