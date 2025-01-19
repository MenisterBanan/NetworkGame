using UnityEngine;
using Unity.Netcode;
using TMPro;
using System;
public class ChatManager : NetworkBehaviour
{
    [SerializeField] ChatMessage chatMessagePrefab;
    [SerializeField] CanvasGroup chatContent;
    [SerializeField] TMP_InputField chatInput;

    public string playerName;

    #region
    public static ChatManager Instance;

    private void Awake()
    {
        ChatManager.Instance = this;
    }
    #endregion

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SentChatMessage(chatInput.text, playerName);
            chatInput.text = "";
        }
    }

    public void SentChatMessage(string message, string sender = null)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            return;
        }
        string S = sender + " > " + message;
        SendChatMessageServerRpc(S);
    }

    void AddMessage(string message)
    {
        ChatMessage chatMessage = Instantiate(chatMessagePrefab, chatContent.transform);
        chatMessage.SetText(message);
    }

    [ServerRpc(RequireOwnership = false)]
    void SendChatMessageServerRpc(string message)
    {
        RecieveChatMessageClientRpc(message);
    }

    [ClientRpc]
    void RecieveChatMessageClientRpc(string message)
    {
        ChatManager.Instance.AddMessage(message);
    }


}
