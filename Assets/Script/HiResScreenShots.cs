using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class HiResScreenShots : MonoBehaviour {
	public RenderTexture overviewTexture;
	public GameObject togleText;
	GameObject OVcamera;
	public string path = "";

	void Start()
	{
		OVcamera = GameObject.Find("OverviewCamera");

		GetComponent<Button> ().onClick.AddListener (() => {
			StartCoroutine(TakeScreenShot());
			togleText.GetComponent<Image>().sprite = Resources.Load("Image/CaptureSuccess_90",typeof(Sprite)) as Sprite;
			togleText.GetComponent<TogleText>().timer = 90;
		});
	}
	/*
	void LateUpdate()
	{

		if (Input.GetKeyDown("f9"))
		{
			StartCoroutine(TakeScreenShot());
		}

	}
	*/
	// return file name
	string fileName(int width, int height)
	{
		return string.Format("screen_{0}x{1}_{2}.png",
			width, height,
			System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
	}

	public IEnumerator TakeScreenShot()
	{
		yield return new WaitForEndOfFrame();

		Camera camOV = OVcamera.GetComponent<Camera>();

		RenderTexture currentRT = RenderTexture.active;

		RenderTexture.active = camOV.targetTexture;
		camOV.Render();
		Texture2D imageOverview = new Texture2D(camOV.targetTexture.width, camOV.targetTexture.height, TextureFormat.RGB24, false);
		imageOverview.ReadPixels(new Rect(0, 0, camOV.targetTexture.width, camOV.targetTexture.height), 0, 0);
		imageOverview.Apply();
		RenderTexture.active = currentRT;


		// Encode texture into PNG
		byte[] bytes = imageOverview.EncodeToPNG();

		// save in memory
		string filename = fileName(Convert.ToInt32(imageOverview.width), Convert.ToInt32(imageOverview.height));
		path = "Snapshots/" + filename;

		System.IO.File.WriteAllBytes(path, bytes);
	}
}