using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class SaveData : MonoBehaviour
{
    public Text userName;
    public Text time;
    public Text coins;
    public Text loading;

    public Text butText;

    public Button newUser;
    public Button exit;
    public Button saveData;
    public GameObject Skip;

    private readonly string baseURL = "http://localhost:7002/";


    // Start is called before the first frame update
    void Start()
    {
        userName.text = PlayerPrefs.GetString("UserName");
        time.text = PlayerPrefs.GetFloat("Time").ToString();
        coins.text = PlayerPrefs.GetInt("Coins").ToString();
        newUser.interactable = false;
        exit.interactable = false;
        loading.enabled = false;
    }

    public void OnButtonClick()
    {
        loading.enabled = true;
        loading.text = "loading...";
        saveData.interactable = false;
        StartCoroutine(SaveDataApi());
    }

    IEnumerator SaveDataApi()
    {
        newUser.interactable = true;
        exit.interactable = true;

        string data;
        if (GameManager0.GetInstane().currentUserState == UserState.guest)
        {
            data = ","+ PlayerPrefs.GetFloat("Time") + "," + PlayerPrefs.GetInt("Coins") + "," + PlayerPrefs.GetString("session_id");
            //data = "," + PlayerPrefs.GetString();
        }
        else
        {
            data = "s," + PlayerPrefs.GetFloat("Time") + "," + PlayerPrefs.GetInt("Coins") + "," + PlayerPrefs.GetString("session_id") + "," + PlayerPrefs.GetString("patient_id");
            
        }
        print(data);
        string apiURL = baseURL + "savedata/" + data;
        print(apiURL);

        // get employee info
        UnityWebRequest InfoRequest = UnityWebRequest.Get(apiURL);
        yield return InfoRequest.SendWebRequest();

        if (InfoRequest.isNetworkError || InfoRequest.isHttpError)
        {
            Debug.LogError(InfoRequest.error);
            loading.text = "";
            saveData.interactable = true;
            yield break;

        }

        JSONNode Info = JSON.Parse(InfoRequest.downloadHandler.text);

        // set UI objects
        print("ok");

        saveData.interactable = false;
        butText.text = "Data saved";
        loading.enabled = false;
        

    }
}
