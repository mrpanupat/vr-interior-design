using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTable : MonoBehaviour {
	//sub menu for each Button.
	public GameObject subMenu;
	public GameObject popBar;
	public bool isSelected = false;
	public static GameObject trackingPanel;
	//last click button
	//private static GameObject lastClick;
	private static Vector3 clickDestination =  new Vector3 (120, -45, -131);
	private Vector3 defaultPosition;

	// Use this for initialization
	void Start () {
		if(trackingPanel == null)
			trackingPanel = FindObject (transform.root.gameObject,"Tracking_Plan_Editor");

		//trigger = false;
		defaultPosition = transform.parent.localPosition;

		//Button click function
		GetComponent<Button> ().onClick.AddListener (() => {
			trackingPanel.SetActive(false);
			popBar.SetActive(false);
			//ToggleMenu.trigger = false;
			//if click move button
			if(isSelected == false){
				ChangeToClickImage();
				transform.parent.parent.gameObject.SetActive(false);
				transform.parent.SetParent(transform.parent.parent.parent);
				isSelected = true;
				/*
				//move last click button back to default location
				if (lastClick != null) {
					lastClick.transform.parent.parent = GameObject.Find("Furniture_Scroll_Menu").transform;
					lastClick.GetComponent<ShowTable> ().isSelected = false;
				}*/
				DisableAllSubMenu();
				subMenu.SetActive(true);
				//lastClick = this.gameObject;
			}else if(isSelected == true){
				//click on same button to back
				GameObject parent =  FindObject(transform.parent.parent.gameObject,"Furniture_Scroll_Menu");
				transform.parent.parent = parent.transform;
				isSelected = false;
				parent.SetActive(true);
				DisableAllSubMenu();
				ChangeToDefaultImage();
			}
			/*
			 // Old code
			if(popBar.activeInHierarchy == false){
				//popBar.SetActive(true);
				trigger = true;

				//Debug.Log("case 1");
			}else if(popBar.activeInHierarchy == true && lastClick != this.gameObject){		//if click as the same button close Furniture panel
				//popBar.SetActive(true);
				trigger = true;
				subMenu.SetActive(true);
				//Debug.Log("case 2");
			}else{
				//popBar.SetActive(false);
				trigger = false;
				//Debug.Log(gameObject.activeSelf + " " + lastClick.name);
			}
			lastClick = this.gameObject;
			*/
		});
	}

	public void FixedUpdate(){
		if (isSelected && !transform.parent.localPosition.Equals(clickDestination)) {
			//move button to Left
			transform.parent.localPosition = Vector3.MoveTowards (transform.parent.localPosition, clickDestination, 600 * Time.deltaTime);
		} else if(!isSelected) {
			transform.parent.localPosition = Vector3.MoveTowards (transform.parent.localPosition, defaultPosition, 600 * Time.deltaTime);
		}
	}
		
	private void DisableAllSubMenu(){
		GameObject subMenu = GameObject.Find("SubMenu");
		for (int i = 0; i < subMenu.transform.childCount; i++)
			subMenu.transform.GetChild (i).gameObject.SetActive (false);
	}
	public void DisableFurniturePanel(){
		DisableAllSubMenu ();
		gameObject.SetActive (false);
	}
	private void ChangeToClickImage(){
		GameObject parentObj = transform.parent.gameObject;
		string imgName = parentObj.GetComponent<Image> ().mainTexture.name;
		imgName = imgName.Substring (0, imgName.IndexOf("_")) + "_AfterClick_80";
		Sprite selectedImg = Resources.Load ("Furniture/" + imgName,typeof(Sprite)) as Sprite;
		parentObj.GetComponent<Image> ().sprite = selectedImg;
		//Debug.Log(selectedImg);
	}
	private void ChangeToDefaultImage(){
		GameObject parentObj = transform.parent.gameObject;
		string imgName = parentObj.GetComponent<Image> ().mainTexture.name;
		imgName = imgName.Substring (0, imgName.IndexOf("_")) + "_80";
		Sprite selectedImg = Resources.Load ("Furniture/" + imgName,typeof(Sprite)) as Sprite;
		parentObj.GetComponent<Image> ().sprite = selectedImg;
		//Debug.Log(selectedImg);
	}

	public static GameObject FindObject(GameObject parent, string name){
		Component[] trs = parent.GetComponentsInChildren (typeof(Transform),true);
		foreach (Transform t in trs) {
			//Debug.Log (t.name);
			if (t.name == name) {
				return t.gameObject;
			}
		}
		return null;
	}
}
