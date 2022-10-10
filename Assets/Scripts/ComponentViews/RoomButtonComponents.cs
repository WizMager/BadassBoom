using TMPro;
using UnityEngine;

namespace ComponentViews
{
    public class RoomButtonComponents : MonoBehaviour
    {
        [SerializeField] private TMP_Text buttonText;

        public TMP_Text GetButtonText => buttonText;
    }
}