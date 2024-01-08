using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using WeChatWASM;

public class Login : MonoBehaviour
{

    public UserData userData = new UserData();

    // Start is called before the first frame update
    void Start()
    {
       



        WX.InitSDK((int code) =>
        {

            //Debug.Log("LeoStartWX Init");
            LoginOption login = new LoginOption();

            login.success = (e) =>
            {
                //Debug.Log("Login success");
                Debug.Log(e.code);

                GetUserInfoOption callBack = new GetUserInfoOption();
                callBack.withCredentials = true;
                callBack.lang = "zh_CN";
                //Debug.Log(e.code);
                callBack.success = (d) =>
                {
                    /*Debug.Log(e.encryptedData);
                    Debug.Log(e.iv);
                    Debug.Log(e.rawData);
                    Debug.Log(e.signature);*/
                    Debug.Log("CallbackSuccessUserInfo " + d.userInfo.nickName);
                   
                    userData.nickname = d.userInfo.nickName;

                    string url = string.Format("https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code", "wx0d63a91e620c58d7", "53ec500637cdf302f569ad6da5064c49", e.code);
                    StartCoroutine(GetRequest(url));


                 
                    // RoleManager.roleData.roleName = d.userInfo.nickName;
                    // RoleManager.roleData.headUrl = d.userInfo.avatarUrl;
                    // Debug.Log(d.userInfo.avatarUrl);
                };
                callBack.complete = (e) =>
                {
                    Debug.Log("Íê³É");
                  

                };
                callBack.fail = (e) =>
                {
                    Debug.Log("Ê§°Ü");
                    Debug.Log(e.errMsg);
                };

                WX.GetUserInfo(callBack);


            };
            WX.Login(login);
          
        });
    }

    // Update is called once per frame
    void Update()
    {

    }


    private IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            if (!string.IsNullOrEmpty(webRequest.error))
            {
                Debug.Log("error:" + webRequest.error);
            }
            else
            {
                UserData data = JsonUtility.FromJson<UserData>(webRequest.downloadHandler.text);
                if (data != null)
                {
                    Debug.Log("data!=null");
                    Debug.Log(data.openid);

                    userData.openid = data.openid;
                    Debug.Log("userData.openid:" + userData.openid);

                    string urlInsert = "https://xingyeren.com/Insert.php";

                    // userData.nickname = "Leonicknametest";
                    string jsonBody = JsonUtility.ToJson(userData);
                    Debug.Log("josnBody:" + jsonBody);
                    StartCoroutine(PostRequest(urlInsert, jsonBody));
                }
              
               
            }
        }

    }
    private IEnumerator PostRequest(string url, string jsonBody)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, jsonBody))
        {
            // Set the content type to indicate JSON data in the request body
            webRequest.SetRequestHeader("Content-Type", "application/json");

            // Convert the JSON string to a byte array
            byte[] bodyData = new System.Text.UTF8Encoding().GetBytes(jsonBody);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyData);

            // Send the POST request
            yield return webRequest.SendWebRequest();

            if (!string.IsNullOrEmpty(webRequest.error))
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                Debug.Log("Response: " + webRequest.downloadHandler.text);
            }
        }
    }
}


public class UserData
{
    public string nickname;
    public string openid;

}