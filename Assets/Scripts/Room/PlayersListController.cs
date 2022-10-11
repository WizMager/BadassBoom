using System;
using System.Collections.Generic;
using ComponentViews;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Room
{
    public class PlayersListController : MonoBehaviour
    {
        [SerializeField] private RectTransform playersContainer;
        [SerializeField] private GameObject playerNicknamePrefab;
        private readonly List<string> _playersNicknames = new List<string>();
        private readonly List<TextLineComponents> _playerTextObjects = new List<TextLineComponents>();

        private void Start()
        {
            var player = PhotonNetwork.NickName;
            PhotonNetwork.RaiseEvent(EventCodePhoton.JoinedRoomEvent, player,
                new RaiseEventOptions {Receivers = ReceiverGroup.MasterClient}, SendOptions.SendReliable);
        }

        private void OnEnable()
        {
            PhotonNetwork.NetworkingClient.EventReceived += EventReceivedHandler;
        }

        private void EventReceivedHandler(EventData data)
        {
            switch (data.Code)
            {
                case EventCodePhoton.JoinedRoomEvent:
                    _playersNicknames.Add((string)data.CustomData);
                    var changedNicknames = _playersNicknames.ToArray();
                    PhotonNetwork.RaiseEvent(EventCodePhoton.UpdatePlayersListEvent, changedNicknames,
                        new RaiseEventOptions {Receivers = ReceiverGroup.All}, SendOptions.SendReliable);
                    break;
                case EventCodePhoton.UpdatePlayersListEvent:
                    UpdatePlayerList((string[])data.CustomData);
                    break;
                case EventCodePhoton.LeftRoomEvent:
                    _playersNicknames.Remove((string) data.CustomData);
                    var clearedNicknames = _playersNicknames.ToArray();
                    PhotonNetwork.RaiseEvent(EventCodePhoton.UpdatePlayersListEvent, clearedNicknames,
                        new RaiseEventOptions {Receivers = ReceiverGroup.All}, SendOptions.SendReliable);
                    break;
            }
        }

        private void UpdatePlayerList(string[] playersNicknames)
        {
            foreach (var playerTextObject in _playerTextObjects)
            {
                Destroy(playerTextObject.gameObject);
            }
            _playerTextObjects.Clear();


            foreach (var playerNickname in playersNicknames)
            {
                var playerNicknameText =
                    Instantiate(playerNicknamePrefab, playersContainer).GetComponent<TextLineComponents>();
                playerNicknameText.GetText.text = playerNickname;
                _playerTextObjects.Add(playerNicknameText);
            }
        }

        private void OnDisable()
        {
            PhotonNetwork.NetworkingClient.EventReceived -= EventReceivedHandler;
        }

        // private void OnDestroy()
        // {
        //     var player = PhotonNetwork.NickName;
        //     PhotonNetwork.RaiseEvent(EventCodePhoton.LeftRoomEvent, player,
        //         new RaiseEventOptions {Receivers = ReceiverGroup.MasterClient}, SendOptions.SendReliable);
        //     PhotonNetwork.NetworkingClient.EventReceived -= EventReceivedHandler;
        // }
    }
}