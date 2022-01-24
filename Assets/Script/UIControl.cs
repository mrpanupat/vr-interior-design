using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

	public GameObject plusButton;
	public GameObject wallPaperButton;
	public GameObject optionButton;
	public GameObject editFurnitureButton;
	public GameObject confirmButton;
	public GameObject cancelButton;
	public GameObject cwButton;
	public GameObject ccwButton;
	public GameObject popFurniture;
	public GameObject housePlan;
	public GameObject trackingPlane;
	public GameObject wallPaperPlane;
	public GameObject controlMenu;
	public GameObject furnitureListButton;
	public GameObject lineList;

	void Start(){
		//make sure trackingPlane initiate
		trackingPlane.SetActive (true);
	}

	public void SetActiveEditFurnitureButton(bool b,bool wallFurniture = false){
		bool activateRotate = b & !wallFurniture;
		popFurniture.SetActive (false);
		confirmButton.SetActive(b);
		cancelButton.SetActive(b);
		cwButton.SetActive(activateRotate);
		ccwButton.SetActive(activateRotate);
	}

	public void SetActiveFurnitureList(bool b){
		CloseAllPlane ();
		furnitureListButton.SetActive (b);
	}

	public void SetActiveHousePlan(bool b){
		CloseAllPlane ();
		trackingPlane.SetActive(b);
		cancelButton.transform.GetChild(0).gameObject.GetComponent<CancelButton>().CancelClick();
		if (b) {
			plusButton.GetComponent<Image>().sprite = Resources.Load ("Image/HousePlan_AfterClick_81", typeof(Sprite)) as Sprite; 
		} else {
			plusButton.GetComponent<Image>().sprite = Resources.Load("Image/HousePlan_80",typeof(Sprite)) as Sprite; 
		}
	}

	public void SetActiveWallPaper(bool b){
		CloseAllPlane ();
		wallPaperPlane.SetActive (b);
		if (b) {
			wallPaperButton.GetComponent<Image>().sprite = Resources.Load ("Image/ChangeWallpaper_AfterClick_80", typeof(Sprite)) as Sprite; 
		} else {
			wallPaperButton.GetComponent<Image>().sprite = Resources.Load("Image/ChangeWallpaper_80",typeof(Sprite)) as Sprite; 
		}
	}

	public void SetActiveControlMenu(bool b){
		CloseAllPlane ();
		controlMenu.SetActive (b);
		if (b) {
			optionButton.GetComponent<Image>().sprite = Resources.Load ("Image/subMenu_AfterClick_80", typeof(Sprite)) as Sprite; 
		} else {
			optionButton.GetComponent<Image>().sprite = Resources.Load("Image/subMenu_80",typeof(Sprite)) as Sprite; 
		}
	}

	public void CloseAllPlane(){
		trackingPlane.SetActive(false);
		furnitureListButton.SetActive (false);
		popFurniture.SetActive(false);
		wallPaperPlane.SetActive (false);
		controlMenu.SetActive (false);
		plusButton.GetComponent<Image>().sprite = Resources.Load("Image/HousePlan_80",typeof(Sprite)) as Sprite; 
		wallPaperButton.GetComponent<Image>().sprite = Resources.Load("Image/ChangeWallpaper_80",typeof(Sprite)) as Sprite; 
		optionButton.GetComponent<Image>().sprite = Resources.Load("Image/subMenu_80",typeof(Sprite)) as Sprite; 
	}
}
