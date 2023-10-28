using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class Web : MonoBehaviour
{

    public Dictionary<string, string> netData = new Dictionary<string, string>();

    private string serverUrl = "http://176.119.159.185:3075/degra_cards/";


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
        StartCoroutine(LoadLicense());
        StartCoroutine(LoadStatistics());
    }

    IEnumerator LoadLicense()
    {
        UnityWebRequest uwr = UnityWebRequest.Get(serverUrl + "license");
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            string parsed = uwr.downloadHandler.text;
            JSONNode data = JSON.Parse(parsed);
            if (data["status"].Value != "True")
            {
                Application.Quit();
            }
        }
    }

    IEnumerator LoadStatistics()
    {
        UnityWebRequest uwr = UnityWebRequest.Get(serverUrl+"da_statistics");
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            string parsed = uwr.downloadHandler.text;
            netData["DonateInfo"] = parsed;
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
}
