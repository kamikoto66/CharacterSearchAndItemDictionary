using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPage : UI {

    Texture2D Capture2D;
    string CharacterName;

    public string characterName
    {
        get { return CharacterName; }
        set { CharacterName = value; }
    }


    // Use this for initialization
    void Start()
    {
        UIHelper.AddButtonListener(Vars["back"], () => {
            UIStack.Instance.PopUI();
        });

        UIHelper.AddButtonListener(Vars["ScreenShot"], onClick);
    }

    public void onClick()
    {
        StartCoroutine(ScreenShot());
    }

    void OnEnable()
    {
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        Camera.main.targetTexture = renderTexture;
        Camera.main.Render();
        RenderTexture.active = renderTexture;

        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        tex.Apply();
        Capture2D = tex;

        //CaptureImg.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, Screen.width, Screen.height), Vector2.zero);

        Camera.main.targetTexture = null;
        RenderTexture.active = null;

        DestroyImmediate(renderTexture);
    }

    public IEnumerator ScreenShot()
    {
        yield return new WaitForEndOfFrame();

        Debug.Log("ScreenShot");

        if (Application.platform == RuntimePlatform.Android)
        {
            string date = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            string myFilename = "myScreenshot_" + date + ".png";
            // string myDefaultLocation = Application.persistentDataPath + "/" + myFilename;
            string myFolderLocation = "/storage/emulated/0/DCIM/";
            string myScreenshotLocation = myFolderLocation + myFilename;


            byte[] bytes = Capture2D.EncodeToPNG();

            // System.IO.File.WriteAllBytes("sdcard/Download/Simg_Capture" + imageCount + ".png", bytes);
            File.WriteAllBytes(myScreenshotLocation, bytes);

            AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");
            // "android.intent.action.MEDIA_SCANNER_SCAN_FILE" <--- 요거 햇갈림.. 원래 찾은건 "android.intent.action.MEDIA_MOUNTED" 요렇게 하라고 나와있는데 안되서 저렇게 하니 됨.
            AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", new object[2] { "android.intent.action.MEDIA_SCANNER_SCAN_FILE", classUri.CallStatic<AndroidJavaObject>("parse", "file://" + myScreenshotLocation) });
            objActivity.Call("sendBroadcast", objIntent);
        }
    }
}
