using TMPro;
using UnityEngine;

namespace ComponentViews
{
    public class TextLineComponents : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public TMP_Text GetText => text;
    }
}