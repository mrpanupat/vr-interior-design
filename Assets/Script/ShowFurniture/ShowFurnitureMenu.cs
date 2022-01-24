using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFurnitureMenu : MonoBehaviour {
	public GameObject furnitureListButton;
	public GameObject housePlan;
	public UIControl uiControl;
	// Use this for initialization
	void Start () {
		uiControl = GameObject.Find ("LMHeadMountedRig").GetComponent<UIControl>();

		//uiControl.SetActiveHousePlan (false);
		GetComponent<Button> ().onClick.AddListener (() => {
			if (furnitureListButton.activeInHierarchy) {
				uiControl.SetActiveFurnitureList(false);
			} else {
				uiControl.SetActiveFurnitureList(true);
			}
		});
	}
}
