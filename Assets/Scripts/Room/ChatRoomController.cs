using ComponentViews;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Room
{
      public class ChatRoomController : MonoBehaviour
      {
            [SerializeField] private TMP_InputField messageInputField;
            [SerializeField] private RectTransform chatContainer;
            [SerializeField] private GameObject textLinePrefab;
            [SerializeField] private ScrollRect chatScrollRect;
            [SerializeField] private int charCountInLineText = 25;
            [SerializeField] private int heightTextLinePrefab = 50;
            [SerializeField] private int maximumChatHeightBeforeChangePosition = 1000;
            private int _currentChatPositionY;
      
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
                        SetupChatContainer();
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

            private void SetupChatContainer()
            {
                  var chatSize = chatContainer.sizeDelta;
                  chatSize.y += heightTextLinePrefab;
                  chatContainer.sizeDelta = chatSize;
                  if (chatSize.y < maximumChatHeightBeforeChangePosition) return;
                  _currentChatPositionY += heightTextLinePrefab;
                  var chatPosition = chatContainer.anchoredPosition;
                  chatPosition.y = _currentChatPositionY;
                  chatScrollRect.enabled = false;
                  chatContainer.anchoredPosition = chatPosition;
                  chatScrollRect.enabled = true;
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
}