using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWallPaperPlane : MonoBehaviour {
	public GameObject wallPlane;
	public GameObject trackingPanel;
	public UIControl uiControl;
	// Use this for initialization
	void Start () {
		uiControl = GameObject.Find ("LMHeadMountedRig").GetComponent<UIControl>();
		if (wallPlane.activeInHierarchy) {
			trackingPanel.SetActive(false);
			ChangeToSelectedImage ();
		} else {
			trackingPanel.SetActive(true);
			ChangeToDefaultImage ();
		}
		GetComponent<Button> ().onClick.AddListener (() => {
			if(wallPlane.activeInHierarchy){
				uiControl.SetActiveWallPaper(false);
			}else{
				uiControl.CloseAllPlane();
				uiControl.SetActiveWallPaper(true);
			}
		});
	}
	public void ChangeToSelectedImage(){
		transform.parent.gameObject.GetComponent<Image> ().sprite = Resources.Load ("Image/ChangeWallpaper_AfterClick_80", typeof(Sprite)) as Sprite;
	}
	public void ChangeToDefaultImage(){
		transform.parent.gameObject.GetComponent<Image> ().sprite = Resources.Load ("Image/ChangeWallpaper_80", typeof(Sprite)) as Sprite;
	}
}
