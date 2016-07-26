using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class TwitchChatService : MonoBehaviour
{
    public class Settings
    {
        public float ChatPositionX = -1.148f;
        public float ChatPositionY = 1.114f;
        public float ChatPositionZ = -0.869f;
        public float ChatRotationX = 0f;
        public float ChatRotationY = -61.296f;
        public float ChatRotationZ = 0f;
        public float ChatScale = 0.002644618f;
        public string Channel;
    }

    public GameObject TwitchChatterPrefab;
    public GameObject TwitchChatterGO;

    void Awake()
    {
        Settings settings2 = new Settings();
        Debug.Log(JsonConvert.SerializeObject(settings2));

        Settings settings = HandleSettings();

        TwitchChatterGO = Instantiate(TwitchChatterPrefab);
        TwitchChatterGO.transform.position = new Vector3(settings.ChatPositionX, settings.ChatPositionY, settings.ChatPositionZ) ;
        TwitchChatterGO.transform.localScale = new Vector3(settings.ChatScale, settings.ChatScale, settings.ChatScale);
        TwitchChatterGO.transform.rotation = Quaternion.Euler(settings.ChatRotationX, settings.ChatRotationY, settings.ChatRotationZ);
        TwitchChatterGO.GetComponent<TwitchChatClient>().JoinChannel(settings.Channel);
        TwitchChatterGO.transform.parent = transform;
        GetComponent<KMGameInfo>().OnStateChange += OnStateChange;
        

    }

    void OnStateChange(KMGameInfo.State newState)
    {
        if(newState == KMGameInfo.State.Gameplay || newState == KMGameInfo.State.Setup || newState == KMGameInfo.State.PostGame)
        {
            TwitchChatterGO.SetActive(true);
        }
        else
        {
            TwitchChatterGO.SetActive(false);
        }
    }

    public Settings HandleSettings()
    {
        return JsonConvert.DeserializeObject<Settings>(GetComponent<KMModSettings>().Settings);
    }
}
