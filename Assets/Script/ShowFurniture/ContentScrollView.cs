using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;

public class ContentScrollView : MonoBehaviour {
	public static string path;
	public static float distance = 7;
	public GameObject confirmButton;
	public GameObject cancelButton;
	public GameObject cwButton;
	public GameObject ccwButton;
	// Use this for initialization

	public void ShowFurnitureList(string path){
		//destroy all children
		foreach (Transform child in transform) {
			Destroy (child.gameObject);
		}
		Sprite bg = Resources.Load ("Furniture/"+path+"/bg", typeof(Sprite)) as Sprite;
		transform.parent.parent.parent.parent.gameObject.GetComponent<Image> ().sprite = bg;
		//add thumbnail of furniture to scrollview
		path = "Furniture/"+path+"/Prefabs";
		//Debug.Log (path);
		GameObject camera = GameObject.Find ("CenterEyeAnchor");
		GameObject furnitureIcon = Resources.Load ("Image/FurnitureIcon", typeof(GameObject)) as GameObject;
		GameObject[] gameObject = Resources.LoadAll<GameObject>(path);
		int i = 0;
		foreach (GameObject m in gameObject)
		{
			//get thumbnail from GameObject
			//convert Texture2D to Sprite
			//set property
			GameObject localImage = Instantiate (furnitureIcon, transform);
			Sprite img = Resources.Load(path+"/"+m.name+"_image",typeof(Sprite)) as Sprite;
			if (img == null)
				Debug.LogError (path + "/" + m.name + "_image");
			//Debug.Log (img);
			localImage.GetComponent<Image>().sprite = img;

			//localImage.GetComponent<RectTransform> ().setA
			localImage.transform.localPosition = new Vector2 (-250 + 150 * i++, 0);
			localImage.transform.localRotation = Quaternion.Euler (0, 0, 0);
			localImage.transform.localScale = Vector2.one;
			//when click on image add furniture to scene
			localImage.GetComponent<Button> ().onClick.AddListener (() => {
				//Distance from camera
				Furniture.hasSelectFurniture = true;
				GameObject addingFur = GameObject.FindGameObjectWithTag("Adding_Furniture");
				if(addingFur != null){
					GameObject.Destroy(addingFur);
				}

				GameObject parentObj = GameObject.Find ("CenterEyeAnchor");
				Vector3 throwPos = parentObj.transform.position + parentObj.transform.forward * distance;
				GameObject tmpObj = Instantiate(m,throwPos,m.transform.rotation,camera.transform);
				Furniture tmpFurniture = tmpObj.GetComponent<Furniture>();
				if(tmpFurniture==null){
					tmpFurniture = tmpObj.AddComponent<Furniture>();
				}
				tmpFurniture.EnableEditMode(true);
				tmpFurniture.furniturePath = path + "/" +m.name;
			});
			//Debug.Log("meshname: " + m.name+" "+preview);
		}
		GameObject content = transform.parent.gameObject;
		RectTransform rect = content.GetComponent<RectTransform> ();
		rect.sizeDelta = new Vector2(-250 + 150 * i,150);
		//GetComponent<RectTransform>().sizeDelta = new Vector2(-250 + 150 * i,150);
		//Debug.Log(rect.sizeDelta);
		cancelButton.transform.GetChild(0).gameObject.GetComponent<CancelButton>().CancelClick();
	}
}
