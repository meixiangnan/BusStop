using UnityEngine;
using UnityEngine.UI;

namespace Watermelon
{
    [RequireComponent(typeof(Button))]
    public class SubbmitScorePanelButton : MonoBehaviour
    {
        public Button Button { get; private set; }

        private void Awake()
        {
            Button = GetComponent<Button>();
            Button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            // Play button sound
            AudioController.PlaySound(AudioController.AudioClips.buttonSound);
        }
    }
}
