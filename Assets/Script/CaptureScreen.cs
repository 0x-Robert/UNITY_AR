using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureScreen : MonoBehaviour
{
    public GameObject CapBtn;
    public void CapBtnSetActive()
    {
        StartCoroutine("TakeScreenshot");

    }


    public IEnumerator TakeScreenshot()
    {
        Debug.Log("Capture");
        yield return new WaitForEndOfFrame();


        string name = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string myFilename = name + ".png";
        string myDefaultLocation = Application.persistentDataPath + "/" + myFilename;
        string myFolderLocation = Application.persistentDataPath + "/../../../../DCIM/Camera/";
        string myScreenshotLocation = myFolderLocation + myFilename;

        if (!System.IO.Directory.Exists(myFolderLocation))
        {
            System.IO.Directory.CreateDirectory(myFolderLocation);
        }

        Application.CaptureScreenshot(myFilename);
        yield return new WaitForSeconds(1.5f);

        print("myDefaultLocation " + myDefaultLocation);
        print("myScreenshotLocation " + myScreenshotLocation);

        System.IO.File.Move(myDefaultLocation, myScreenshotLocation);
        print("hahaha");

        AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", new object[2] { "android.intent.action.MEDIA_SCANNER_SCAN_FILE",
    classUri.CallStatic<AndroidJavaObject>("parse", "file://" + myScreenshotLocation) });
        objActivity.Call("sendBroadcast", objIntent);

    }




}
