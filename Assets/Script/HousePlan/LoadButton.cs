using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour {
	public GameObject togleText;
	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (() => {
			BluePrintData.clear ();
			DotScript.ClearAll();
			DotScript.oldList.Clear ();
			foreach(GameObject g in Furniture.furnitureInScene){
				Destroy(g);
			}
			Furniture.furnitureInScene.Clear();

			SaveLoad.LoadScene();
			togleText.GetComponent<Image>().sprite = Resources.Load("Image/LoadSuccess_90",typeof(Sprite)) as Sprite;
			togleText.GetComponent<TogleText>().timer = 90;
		});
	}
}
