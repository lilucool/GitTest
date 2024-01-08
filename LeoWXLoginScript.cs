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
            // 打印屏幕信息
            var systemInfo = WX.GetSystemInfoSync();
            Debug.Log($"{systemInfo.screenWidth}:{systemInfo.screenHeight}, {systemInfo.windowWidth}:{systemInfo.windowHeight}, {systemInfo.pixelRatio}");

            // 创建用户信息获取按钮，在底部区域创建一个300高度的透明区域
            // 首次获取会弹出用户授权窗口, 可通过右上角-设置-权限管理用户的授权记录
            var canvasWith = (int)(systemInfo.screenWidth * systemInfo.pixelRatio);
            var canvasHeight = (int)(systemInfo.screenHeight * systemInfo.pixelRatio);
            var buttonHeight = (int)(canvasWith / 1080f * 300f);
            infoButton = WX.CreateUserInfoButton(0, canvasHeight - buttonHeight, canvasWith, buttonHeight, "zh_CN", false);
            Debug.Log(infoButton);
            infoButton.OnTap((userInfoButonRet) =>
            {
                Debug.Log(JsonUtility.ToJson(userInfoButonRet.userInfo));
                txtUserInfo.text = $"nickName：{userInfoButonRet.userInfo.nickName}， avartar:{userInfoButonRet.userInfo.avatarUrl}";
            });
            Debug.Log("infoButton Created");



            // 授权
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
                
                        // 是否已授权过SYS_MSG_TYPE_INTERACTIVE，授权过不在乎展示按钮
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


            //方法二
            

        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
