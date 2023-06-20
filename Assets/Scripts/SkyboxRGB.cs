using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRGB : MonoBehaviour
{
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public Color color3 = Color.gray;
    public bool coloredSky = false;
    public float duration = 3.0F;

    public Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    void Update()
    {
        if (coloredSky)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            cam.backgroundColor = Color.Lerp(color1, color2, t);
        }
        else
        {
            cam.backgroundColor = color3;
        }

    }
}
