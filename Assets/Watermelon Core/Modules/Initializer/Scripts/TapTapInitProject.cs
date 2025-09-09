using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TapSDK.Core;

namespace Watermelon
{
    public class TapTapInitProject : MonoBehaviour
    {
        private void Awake()
        {
            InitTapTap();
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
            // 设置屏幕方向：0-竖屏 1-横屏
            coreOptions.screenOrientation = 0;
            // TapSDK 初始化
            TapTapSDK.Init(coreOptions);
        }
    }
}
