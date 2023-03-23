using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Sharebtn : MonoBehaviour
{
	public GameObject UI;
	private string shareMessage;
    public void ClickShareButton()
    {
		shareMessage = "Check this app by me!";
		UI.SetActive(false);
		StartCoroutine(TakeScreenshotAndShare());
		
	}

	private IEnumerator TakeScreenshotAndShare()
	{
		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

		string name = "ScreenshotLuthfan"
		   + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")
		   + ".png";

		//PC
		//byte[] bytes = ss.EncodeToPNG();
		//File.WriteAllBytes(Application.dataPath + "/../"+ name, bytes);


		//mobile
		NativeGallery.SaveImageToGallery(ss, "LuthfanApp pictures", name);
		// To avoid memory leaks
		Destroy(ss);
		UI.SetActive(true);

		new NativeShare().AddFile(filePath)
			.SetSubject("Luthfan App").SetText(shareMessage).SetUrl("https://github.com/luthfanersa")
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();

		
	}
}
