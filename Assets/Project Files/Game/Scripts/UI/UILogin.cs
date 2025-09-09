
using System;
using TapSDK.Core;
using UnityEngine;
using UnityEngine.UI;
using TapSDK.Login;
using System.Threading.Tasks;
using System.Collections.Generic;
using TapSDK.Leaderboard;
using System.Net.Security;

namespace Watermelon
{
    public class UILogin : UIPage
    {
        [SerializeField] TapTapLoginProject taptapLoginProject;
        
        [SerializeField] Button loginButton;

        public void Awake()
        {
            loginButton.onClick.AddListener(OnLoginButtonClicked);
           
        }

        public override void Init()
        {
            
        }
        
        private void OnLoginButtonClicked()
        {
            Debug.Log("OnLoginButtonClicked");
            #if UNITY_EDITOR
                GameLoading.LoadGameScene();
            #endif
            #if UNITY_ANDROID
                /*if (taptapLoginProject)
                {
                    taptapLoginProject.OnTapTapLogin();
                }*/
            #endif
            
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
