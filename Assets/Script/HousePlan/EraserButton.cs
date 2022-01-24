using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EraserButton : MonoBehaviour {
	public GameObject pencilButton;
	// Use this for initialization
	void Start () {
		if (!DotScript.isWrite) {
			transform.parent.gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Eraser_AfterClick_81",typeof(Sprite)) as Sprite;
		}
		GetComponent<Button> ().onClick.AddListener (() => {
			pencilButton.GetComponent<Image>().sprite = Resources.Load("Image/Edit_80",typeof(Sprite)) as Sprite;
			DotScript.isWrite = false;
			transform.parent.gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Eraser_AfterClick_81",typeof(Sprite)) as Sprite;
		});
	}
}
