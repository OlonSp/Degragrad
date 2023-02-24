using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    private string widgetToken = "";

    public Dictionary<string, string> netData = new Dictionary<string, string>();

    private Dictionary<string, string> urlInfo = new Dictionary<string, string>()
    {
        { "DonateInfo", "https://www.donationalerts.com/api/v1/widgets/stat/1524523/stat" }
    };

    private static Web instance;

    public delegate void OnDataLoadedDelegate();
    public static OnDataLoadedDelegate OnDataLoaded;


    public static Web me
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.Find("Web").GetComponent<Web>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(LoadToken());
        StartCoroutine(WaitForAllDataLoaded());
    }

    IEnumerator WaitForAllDataLoaded()
    {
        while (netData.Count != urlInfo.Count)
        {
            yield return new WaitForSeconds(0.2f);
        }
        OnDataLoaded?.Invoke();
        ControllerUI.inst.webBlock.SetActive(false);
    }

    IEnumerator LoadToken()
    {
        UnityWebRequest uwr = UnityWebRequest.Get("https://www.donationalerts.com/widget/stream-stats/1524523?token=T9Be1HpILtDH5tEI5ZXN");
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            string parsed = uwr.downloadHandler.text.Replace("window.token_widget_streamer = \"", "~").Split('~')[1];
            parsed = parsed.Replace("\";", "~").Split('~')[0];
            widgetToken = parsed;

            foreach (string key in urlInfo.Keys)
            {
                yield return LoadDAResponse(key);
            }
            
        }
    }

    IEnumerator LoadDAResponse(string urlKey)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(urlInfo[urlKey]);
        uwr.SetRequestHeader("authorization", "Bearer " + widgetToken);
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            netData[urlKey] = uwr.downloadHandler.text;
            print(uwr.downloadHandler.text);
        }
    }

    public string GetData(string key)
    {
        if (!netData.ContainsKey(key))
        {
            return "";
        }
        return netData[key];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
