using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Scrnshot : MonoBehaviour
{
    public GameObject SSHolder;

    public GameObject UI;
    private void Start()
    {
        
    }

    private void Update()
    {
            
    }

    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string name = "ScreenshotLuthfan"
            + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")
            + ".png";

        //PC
        //byte[] bytes = ss.EncodeToPNG();
        //File.WriteAllBytes(Application.dataPath + "/../"+ name, bytes);

        
        //mobile
        NativeGallery.SaveImageToGallery(ss, "LuthfanApp pictures", name);
        
        Destroy(ss);
        UI.SetActive(true);
    }

    public void TakeScreenshot()
    {
        UI.SetActive(false);
        StartCoroutine("Screenshot");
    }
}
