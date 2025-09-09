using UnityEngine;
using UnityEngine.UI;

namespace Watermelon
{
    [RequireComponent(typeof(Button))]
    public class RankShowPanelButton : MonoBehaviour
    {
        public Button Button { get; private set; }

        private void Awake()
        {
            Button = GetComponent<Button>();
            Button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            TapTapLeaderboardProject._instance.OpenLeaderboard("eczh0r4byaq5ho9kaf","public");   

            // Play button sound
            AudioController.PlaySound(AudioController.AudioClips.buttonSound);
        }
    }
}
