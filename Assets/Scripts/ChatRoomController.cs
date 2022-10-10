using ComponentViews;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class ChatRoomController : MonoBehaviour
{
      [SerializeField] private TMP_InputField messageInputField;
      [SerializeField] private RectTransform chatContainer;
      [SerializeField] private GameObject textLinePrefab;
      [SerializeField] private int charCountInLineText = 25;
      [SerializeField] private float heightTextLinePrefab = 50f;
      
      private void Start()
      {
            messageInputField.onEndEdit.AddListener(OnEndWriteMessageHandler);
      }

      private void OnEnable()
      {
            PhotonNetwork.NetworkingClient.EventReceived += EventReceivedHandler;
      }

      private void OnEndWriteMessageHandler(string message)
      {
            if (string.IsNullOrWhiteSpace(message)) return;
            var textWithNick = $"{PhotonNetwork.LocalPlayer.NickName}:{message}";
            messageInputField.text = "";
            PhotonNetwork.RaiseEvent(EventCodePhoton.SendMessageEvent, textWithNick, new RaiseEventOptions{Receivers = ReceiverGroup.All}, SendOptions.SendReliable);
      }

      private void SetupMessage(string message)
      {
            var messageChars = message.ToCharArray();
            var textLineNeedCount = message.Length / 25;
            var lastLineCharCount = message.Length % 25;
            if (lastLineCharCount > 0)
            {
                  textLineNeedCount++;
            }
            for (int i = 0; i < textLineNeedCount; i++)
            {
                  var chatSize = chatContainer.sizeDelta;
                  chatSize.y += heightTextLinePrefab;
                  chatContainer.sizeDelta = chatSize;
                  var tmpText = Instantiate(textLinePrefab, chatContainer).GetComponent<TextLineComponents>().GetText;
                  char[] lineText;
                  if (i == textLineNeedCount - 1)
                  {
                        lineText = new char[lastLineCharCount];
                        for (int j = charCountInLineText * i; j < charCountInLineText * i + lastLineCharCount; j++)
                        {
                              lineText[j - charCountInLineText * i] = messageChars[j];
                        } 
                  }
                  else
                  {
                        lineText = new char[charCountInLineText];
                        for (int j = charCountInLineText * i; j < charCountInLineText * (i + 1); j++)
                        {
                              lineText[j - charCountInLineText * i] = messageChars[j];
                        }    
                  }
                  var completeMessage = new string(lineText);
                  tmpText.text = $"{completeMessage}";
            }
      }

      private void EventReceivedHandler(EventData data)
      {
            switch (data.Code)
            {
                  case EventCodePhoton.SendMessageEvent:
                        SetupMessage((string)data.CustomData);
                        break;
            }  
      }
      
      private void OnDisable()
      {
            PhotonNetwork.NetworkingClient.EventReceived -= EventReceivedHandler;
      }

      private void OnDestroy()
      {
            messageInputField.onEndEdit.RemoveListener(OnEndWriteMessageHandler); 
      }
}