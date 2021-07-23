using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class SignIn : MonoBehaviour
{
    public Button signIn;
    public Button playGuest;
    public Button skip;
    public TMP_InputField email;
    public TMP_InputField password;

    public Text errorSignIn;

    private int guestNum;

    private readonly string baseURL = "http://localhost:7002/";


    private void Start()
    {
        errorSignIn.enabled = false;
        email.text = "";
        password.text = "";

    }

    public void OnButtonClick(bool guest)
    {
        errorSignIn.enabled = true;
        errorSignIn.text = "loading...";
        StartCoroutine(SignInApi(guest));
    }

    IEnumerator SignInApi(bool guest)
    {
        string data;
        if (guest)
        {
            GameManager0.GetInstane().currentUserState = UserState.guest;
            data = "";
        }
        else
        {
            GameManager0.GetInstane().currentUserState = UserState.registered;
            data = email.text + "," + password.text;
            print(data);
        }
        string apiURL = baseURL + "signin/" + data;
        print(apiURL);
        // get employee info
        UnityWebRequest InfoRequest = UnityWebRequest.Get(apiURL);
        yield return InfoRequest.SendWebRequest();

        if (InfoRequest.isNetworkError || InfoRequest.isHttpError)
        {
            Debug.LogError(InfoRequest.error);
            errorSignIn.text = InfoRequest.error;
            errorSignIn.text += "\nerror!";
            yield break;

        }

        JSONNode Info = JSON.Parse(InfoRequest.downloadHandler.text);

        // set UI objects
        PlayerPrefs.SetString("UserName", Info["name"]);
        PlayerPrefs.SetString("session_id", Info["session_id"]);
        PlayerPrefs.SetString("patient_id", Info["patient_id"]);
        errorSignIn.text = "validation : " + Info["validation"] + "\nmessage : " + Info["message"];
        if (Info["validation"] == "valid")
        {
            print("valid");
            GameManager0.GetInstane().GoToChoseGame();
        }       
    }
   
    public void DefaultSignIn()
    {
        if ((email.text == "ahmed" && password.text == "1234") || (email.text == "salma" && password.text == "56789"))
        {
            GameManager0.GetInstane().userName = email.text;
            GameManager0.GetInstane().password = password.text;
            PlayerPrefs.SetString("UserName", email.text);

            PlayerPrefs.SetString("UserName", "Ahmed");
            PlayerPrefs.SetString("session_id", "100");
            PlayerPrefs.SetString("patient_id", "5");
            GameManager0.GetInstane().currentUserState = UserState.registered;

            GameManager0.GetInstane().GoToChoseGame();
        }
        else
        {
            errorSignIn.text = "Incorrect User name or Password";
        }
    }
    public void SignInCheck()
    {
        if ((email.text == "ahmed" && password.text == "1234") || (email.text == "salma" && password.text == "56789"))
        {
            GameManager0.GetInstane().userName = email.text;
            GameManager0.GetInstane().password = password.text;
            PlayerPrefs.SetString("UserName", email.text);
            GameManager0.GetInstane().currentUserState = UserState.registered;

            GameManager0.GetInstane().GoToChoseGame();
        }
        else
        {
            errorSignIn.enabled = true;
        }
    }

    
    public void Guest()
    {
        guestNum = PlayerPrefs.GetInt("guestNum");
        guestNum += 1;
        string guest = "guest" + guestNum.ToString();
        PlayerPrefs.SetInt("guestNum", guestNum);
        GameManager0.GetInstane().userName = guest;
        PlayerPrefs.SetString("UserName", guest);
        GameManager0.GetInstane().currentUserState = UserState.guest;

        GameManager0.GetInstane().GoToChoseGame();
    }
    
}
