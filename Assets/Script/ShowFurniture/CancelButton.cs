using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelButton : MonoBehaviour {
	public GameObject cwButton;
	public GameObject ccwButton;
	public GameObject confirmButton;
	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (() => {
			CancelClick();
		});
	}
		
	public void CancelClick(){
		//remove game object from scene
		GameObject furniture = GameObject.FindGameObjectWithTag("Adding_Furniture");
		if (furniture != null) {
			Furniture.furnitureInScene.Remove (furniture);
			Destroy (furniture);
		}
		transform.parent.gameObject.SetActive(false);
		confirmButton.SetActive(false);
		cwButton.SetActive(false);
		ccwButton.SetActive(false);
		Furniture.hasSelectFurniture = false;
		if (SubMenuButton.lastClick != null) {
			SubMenuButton.lastClick.GetComponent<SubMenuButton> ().changeToDefaultImage ();
		}
	}
}
