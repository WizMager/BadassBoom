using System;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentViews
{
    public class RoomButtonComponents : MonoBehaviour
    {
        public Action<string, RoomButtonComponents> OnRoomClick;
        [SerializeField] private TMP_Text buttonText;
        [SerializeField] private Button button;

        public TMP_Text GetButtonText => buttonText;

        private void Start()
        {
            button.onClick.AddListener(OnClickHandler);
        }

        private void OnClickHandler()
        {
            OnRoomClick?.Invoke(PhotonNetwork.LocalPlayer.UserId, this);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnClickHandler);
        }
    }
}