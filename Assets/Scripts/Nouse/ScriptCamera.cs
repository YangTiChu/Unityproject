using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScriptsCamera : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture backCam;
    private WebCamTexture frontCam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

    // Use this for initialization
    private void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (var i = 0; i < devices.Length; i++)
        {
            Debug.Log(devices[i].name);
            Debug.Log(i);
        }
        defaultBackground = background.texture;
        //WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            Debug.Log("No camera detected");
            camAvailable = false;
            return;
        }

        //if (!devices [1].isFrontFacing) {    //開啟後鏡頭
        if (devices[2].isFrontFacing)
        {    //開啟前鏡頭
            backCam = new WebCamTexture(devices[2].name, Screen.width, Screen.height);
        }

        if (backCam == null)
        {
            Debug.Log("Unable to find back camera");
            return;
        }
        //Debug.Log(backCam);
        backCam.Play();
        background.texture = backCam;

        camAvailable = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!camAvailable)
            return;

        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        //        background.rectTransform.localScale = new Vector3 (1f, scaleY, 1f);    //非鏡像
        background.rectTransform.localScale = new Vector3(-1f, scaleY, 1f);    //鏡像

        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
}