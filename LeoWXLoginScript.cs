using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WeChatWASM;

public class LeoWXLoginScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Text txtUserInfo;
    public Text txtTestWXFont;
    public WXFileSystemManager fs = new WXFileSystemManager();
    public WeChatWASM.WXEnv env = new WXEnv();
    private WXUserInfoButton infoButton;


    void Start()
    {
        Debug.Log("1115");
        WX.InitSDK((code) =>

       
        {
            // ��ӡ��Ļ��Ϣ
            var systemInfo = WX.GetSystemInfoSync();
            Debug.Log($"{systemInfo.screenWidth}:{systemInfo.screenHeight}, {systemInfo.windowWidth}:{systemInfo.windowHeight}, {systemInfo.pixelRatio}");

            // �����û���Ϣ��ȡ��ť���ڵײ����򴴽�һ��300�߶ȵ�͸������
            // �״λ�ȡ�ᵯ���û���Ȩ����, ��ͨ�����Ͻ�-����-Ȩ�޹����û�����Ȩ��¼
            var canvasWith = (int)(systemInfo.screenWidth * systemInfo.pixelRatio);
            var canvasHeight = (int)(systemInfo.screenHeight * systemInfo.pixelRatio);
            var buttonHeight = (int)(canvasWith / 1080f * 300f);
            infoButton = WX.CreateUserInfoButton(0, canvasHeight - buttonHeight, canvasWith, buttonHeight, "zh_CN", false);
            Debug.Log(infoButton);
            infoButton.OnTap((userInfoButonRet) =>
            {
                Debug.Log(JsonUtility.ToJson(userInfoButonRet.userInfo));
                txtUserInfo.text = $"nickName��{userInfoButonRet.userInfo.nickName}�� avartar:{userInfoButonRet.userInfo.avatarUrl}";
            });
            Debug.Log("infoButton Created");



            // ��Ȩ
            WX.GetSetting(new GetSettingOption()
            {
                withSubscriptions = true,
                success = (res) =>
                {
                    Dictionary<string, string> itemSettings = res.subscriptionsSetting.itemSettings;
                  
                    Debug.Log(res.authSetting);
                    foreach (var item in res.authSetting)
                    {
                        Debug.Log($"key={item.Key},value={item.Value}");
                    }
                    if (!res.authSetting["scope.address"])
                    {
                        Debug.Log("no info");
                    }
                    else 
                    {
                        Debug.Log("have info");

                    }
                
                        // �Ƿ�����Ȩ��SYS_MSG_TYPE_INTERACTIVE����Ȩ�����ں�չʾ��ť
                        Debug.Log("GetSetting success" );
                    Debug.Log(itemSettings);
                    if (itemSettings.ContainsKey("SYS_MSG_TYPE_INTERACTIVE") && itemSettings["SYS_MSG_TYPE_INTERACTIVE"] == "accept")
                    {
                        GameObject requestSubscribeButton = GameObject.Find("RequestSubscribeSystemMessage");
                        if (requestSubscribeButton != null)
                        {
                            requestSubscribeButton.SetActive(false);
                        }
                    }
                },
                fail = (res) =>
                {
                    Debug.Log("GetSetting fail" + JsonUtility.ToJson(res));
                }
            });


            //������
            

        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
