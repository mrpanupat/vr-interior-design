using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PencilButton : MonoBehaviour {
	public GameObject eraserButton;
	// Use this for initialization
	void Start () {
		if (DotScript.isWrite) {
			transform.parent.gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Edit_AfterClick_81",typeof(Sprite)) as Sprite;
		}
		GetComponent<Button> ().onClick.AddListener (() => {
			eraserButton.GetComponent<Image>().sprite = Resources.Load("Image/Eraser_80",typeof(Sprite)) as Sprite;
			DotScript.isWrite = true;
			transform.parent.gameObject.GetComponent<Image>().sprite = Resources.Load("Image/Edit_AfterClick_81",typeof(Sprite)) as Sprite;
		});
	}
}
