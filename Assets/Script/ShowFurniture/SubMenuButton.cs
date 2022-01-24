using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenuButton : MonoBehaviour {
	public string furniturePath;
	private string imgPath;
	private string imageName;
	private GameObject popFurniture;
	public static GameObject lastClick;
	// Use this for initialization
	void Start () {
		imgPath = "Furniture/"+transform.parent.parent.name;
		imageName = transform.parent.gameObject.GetComponent<Image> ().mainTexture.name;
		imageName = imageName.Substring (0, imageName.IndexOf ("_"));
		popFurniture = FindObject (transform.root.gameObject,"Pop_Furniture");
		GetComponent<Button> ().onClick.AddListener (() => {
			if(lastClick!=null){
				lastClick.GetComponent<SubMenuButton>().changeToDefaultImage();
			}
			if(lastClick == this.gameObject && popFurniture.activeInHierarchy){
				changeToDefaultImage();
				popFurniture.SetActive(false);
				lastClick = null;
			}else{
				changeToClickImage();
				ContentScrollView.path = furniturePath;
				popFurniture.GetComponentInChildren<ContentScrollView>().ShowFurnitureList(furniturePath);
				popFurniture.SetActive(true);
				lastClick = this.gameObject;
			}
		});
	}
	public void changeToClickImage(){
		Sprite image = Resources.Load(imgPath+"/"+imageName+"_AfterClick_80",typeof(Sprite)) as Sprite;
		transform.parent.GetComponent<Image> ().sprite = image;	
		Debug.Log (imgPath+"/"+imageName);
	}
	public void changeToDefaultImage(){
		Sprite image = Resources.Load(imgPath+"/"+imageName+"_80",typeof(Sprite)) as Sprite;
		transform.parent.GetComponent<Image> ().sprite = image;	
		Debug.Log (furniturePath+"/"+imageName);
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
