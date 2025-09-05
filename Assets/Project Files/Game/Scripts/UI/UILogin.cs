
using System;
using TapSDK.Core;
using UnityEngine;
using UnityEngine.UI;
using TapSDK.Login;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Watermelon
{
    public class UILogin : UIPage
    {
        
        [SerializeField] Button loginButton;

        public void Awake()
        {
            loginButton.onClick.AddListener(OnLoginButtonClicked);
            InitTapTap();
        }

        public override void Init()
        {
            
        }
        
        private void OnLoginButtonClicked()
        {
            Debug.Log("OnLoginButtonClicked");
            OnTapTapLogin();
        }

        private void InitTapTap()
        {
            // 核心配置
            TapTapSdkOptions coreOptions = new TapTapSdkOptions
            {
                // 客户端 ID，开发者后台获取
                clientId = "3tgdodo2sptiucsu95",
                // 客户端令牌，开发者后台获取
                clientToken = "6BKniaVJPOHQwllPMMaVF2FoXAoJZaHS8JSXHPKz",
                // 地区，CN 为国内，Overseas 为海外
                region = TapTapRegionType.CN,
                // 语言，默认为 Auto，默认情况下，国内为 zh_Hans，海外为 en
                preferredLanguage = TapTapLanguageType.zh_Hans,
                // 是否开启日志，Release 版本请设置为 false
                enableLog = true
            };
// TapSDK 初始化
            TapTapSDK.Init(coreOptions);
        }

        private async void OnTapTapLogin()
        {
            try
            {
                // 定义授权范围
                List<string> scopes = new List<string>
                {
                    TapTapLogin.TAP_LOGIN_SCOPE_PUBLIC_PROFILE
                };
                // 发起 Tap 登录
                var userInfo = await TapTapLogin.Instance.LoginWithScopes(scopes.ToArray());
                Debug.Log($"登录成功，当前用户 ID：{userInfo.unionId}");
            }
            catch (TaskCanceledException)
            {
                Debug.Log("用户取消登录");
            }
            catch (Exception ex)
            {
                Debug.Log($"登录失败，出现异常：{ex}");
            }
        }

        public override void PlayHideAnimation()
        {
            throw new System.NotImplementedException();
        }

        public override void PlayShowAnimation()
        {
            throw new System.NotImplementedException();
        }
    }
}
