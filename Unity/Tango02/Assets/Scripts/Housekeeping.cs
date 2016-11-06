using System.Globalization;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Housekeeping : MonoBehaviour
    {
        private float _fullscreenTimer;
        private readonly float _fullscreenTimeout = 3;

        [UsedImplicitly] public Text Debug1;
        [UsedImplicitly] public Text Debug2;

        [UsedImplicitly]
        private void Start ()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
	
        [UsedImplicitly]
        void Update () {

#if UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                Screen.fullScreen = false;
                _fullscreenTimer = _fullscreenTimeout;
            }

            if (_fullscreenTimer > 0)
            {
                _fullscreenTimer = _fullscreenTimer - Time.deltaTime;
            }
            else if (_fullscreenTimer <= 0 && !Screen.fullScreen)
            {
                Screen.fullScreen = true;
            }

            Debug1.text = _fullscreenTimer.ToString(CultureInfo.InvariantCulture);
            Debug2.text = Screen.fullScreen.ToString();
#endif

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
