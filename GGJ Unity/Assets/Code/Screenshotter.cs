using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshotter : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            string screenshotFileName = "ZAMH" + PlayerPrefs.GetInt("screenshotIndex") + ".PNG";
            print(screenshotFileName + " Captured");
            ScreenCapture.CaptureScreenshot(screenshotFileName);
            PlayerPrefs.SetInt("screenshotIndex", PlayerPrefs.GetInt("screenshotIndex") + 1);
        }
    }
}
