using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowControlMenu : MonoBehaviour {
	public GameObject subMenu;
	public UIControl uiControl;
	// Use this for initialization
	void Start () {
		uiControl = GameObject.Find ("LMHeadMountedRig").GetComponent<UIControl>();
		if(subMenu.activeInHierarchy)
			ChangeToSelectedImage();
		else
			ChangeToDefaultImage();
		
		GetComponent<Button>().onClick.AddListener (() => {
			if(subMenu.activeInHierarchy){
				uiControl.SetActiveControlMenu(false);
			}else{
				uiControl.CloseAllPlane();
				uiControl.SetActiveControlMenu(true);
			}
		});
	}

	private void ChangeToSelectedImage(){
		transform.parent.gameObject.GetComponent<Image> ().sprite = Resources.Load ("Image/subMenu_AfterClick_80", typeof(Sprite)) as Sprite;
	}
	private void ChangeToDefaultImage(){
		transform.parent.gameObject.GetComponent<Image> ().sprite = Resources.Load ("Image/subMenu_80", typeof(Sprite)) as Sprite;
	}

}
