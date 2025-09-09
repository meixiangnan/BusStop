using System;
using UnityEngine;
using TapSDK.Login;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Watermelon
{
    public class TapTapLoginProject : MonoBehaviour
    {
        // Start is called before the first frame update
        public async void OnTapTapLogin()
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
                Debug.Log($"mei 登录成功，当前用户 ID：{userInfo.unionId}");
                if (userInfo.unionId != null)
                {
                    TapTapAccount taptapAccount = await TapTapLogin.Instance.GetCurrentTapAccount();
                    AccessToken accessToken = taptapAccount.accessToken;
                    string openId = taptapAccount.openId;   
                    Debug.Log($"mei 登录成功，当前用户 openId：{openId}");
                }
                GameLoading.LoadGameScene();
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
    }
}
