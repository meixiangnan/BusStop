using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TapSDK.Leaderboard;

namespace Watermelon
{
    public class TapTapLeaderboardProject : MonoBehaviour
    {
        public static TapTapLeaderboardProject _instance;
        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }
        
        // Start is called before the first frame update
        void Start()
        {
        }

        public void OpenLeaderboard(string leaderboardId, string type)
        {
            Debug.Log("mei OpenLeaderboard:"+leaderboardId+" "+type);
            TapTapLeaderboard.OpenLeaderboard(leaderboardId, type);
        }

        public void SubmitScores(int Score)
        {
            // 单个分数提交
            var singleScore = new List<SubmitScoresRequest.ScoreItem>
            {
                new SubmitScoresRequest.ScoreItem
                {
                    LeaderboardId = "eczh0r4byaq5ho9kaf",
                    Score = Score
                }
            };
                
            // 提交分数并处理回调
            var callback = new TapTapTapTapLeaderboardResponseCallback<SubmitScoresResponse>
            {
                OnSuccessAction = (result) => {
                    // 提交成功
                    Debug.Log("mei 提交分数成功");
                },
                OnFailureAction = (code, message) => {
                    Debug.Log("mei 提交分数失败："+code);
                    // 提交失败
                    // 根据错误码处理不同的错误情况
                    switch (code)
                    {
                        case 500000:
                            // 排行榜周期已过期
                            break;
                        case 500001:
                            // 排行榜 ID 未找到
                            break;
                        case 500002:
                            // 排行榜参数错误
                            break;
                        case 500101:
                            // 用户未授权
                            break;
                        case 500102:
                            // 用户未登录
                            break;
                        case 500199:
                            // 未知错误
                            break;
                        default:
                            // 其他错误
                            break;
                    }
                }
            };

            TapTapLeaderboard.SubmitScores(singleScore, callback);
        }
    }
}
