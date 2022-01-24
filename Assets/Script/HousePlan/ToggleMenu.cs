using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMenu : MonoBehaviour {
	public GameObject mainMenu;
	public GameObject furnitureListButton;
	public GameObject popBar;
	public GameObject cancelButton;
	private UIControl uiControl;
	// Use this for initialization
	void Start () {
		uiControl = GameObject.Find ("LMHeadMountedRig").GetComponent<UIControl>();

		if(mainMenu.activeInHierarchy == true){
			uiControl.SetActiveHousePlan(true);
		}else if(mainMenu.activeInHierarchy == false){
			uiControl.SetActiveHousePlan(false);
		}

		GetComponent<Button> ().onClick.AddListener (() => {
			furnitureListButton.SetActive(false);
			if(mainMenu.activeInHierarchy == false){
				uiControl.SetActiveHousePlan(true);
				DotScript.RestoreOldLine();
			}else if(mainMenu.activeInHierarchy ==true){
				uiControl.SetActiveHousePlan(false);
			}
		});
	}
}
