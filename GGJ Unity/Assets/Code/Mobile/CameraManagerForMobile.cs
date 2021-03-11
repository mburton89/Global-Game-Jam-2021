using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerForMobile : MonoBehaviour
{
    //camera size for 1:2 (0.5) == 10.3
    //camera size for 3:4 (0.75) == 6.9

    void Start()
    {
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        float cameraSize;
        cameraSize = (1.25f - aspectRatio) * 12.8f;
        Camera.main.orthographicSize = cameraSize;
    }
}
