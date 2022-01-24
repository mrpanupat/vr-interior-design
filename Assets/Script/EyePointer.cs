using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePointer : MonoBehaviour {
	private static Vector3 ceilingContactPoint;
	private static Vector3 wallContactPoint;
	private static float wallAngle;
	private static Vector3 terrainContactPoint;
	private static UIControl uiControl;
	// Use this for initialization
	void Start(){
		uiControl = GameObject.Find ("LMHeadMountedRig").GetComponent<UIControl>();
	}
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		uiControl.editFurnitureButton.SetActive (false);
		if (Physics.Raycast (transform.parent.position, transform.parent.forward,out hit)) {
			if (hit.collider.gameObject.tag.Equals ("Wall")) {
				wallContactPoint = hit.point;
				wallAngle = hit.collider.gameObject.transform.localRotation.eulerAngles.z + hit.collider.gameObject.transform.parent.rotation.eulerAngles.y;
				//Debug.Log ("Parent:" + hit.collider.gameObject.transform.parent.localRotation.eulerAngles);
				//Debug.Log (wallAngle);
			}else if (hit.collider.gameObject.tag.Equals ("Terrain")){
				terrainContactPoint = hit.point;
			}else if (hit.collider.gameObject.tag.Equals ("Ceiling")){
				ceilingContactPoint = hit.point;
			}
			if(hit.collider.gameObject.tag.Equals ("Furniture")&&!Furniture.hasSelectFurniture){
				uiControl.editFurnitureButton.transform.GetChild(0).gameObject.GetComponent<EditFurnitureButton>().selectFurniture = hit.collider.gameObject;
				uiControl.editFurnitureButton.SetActive (true);
			}
			//Debug.Log (hit.collider.gameObject.tag);
		}
	}

	public static Vector3 GetCeilingContactPoint(){
		return ceilingContactPoint;
	}
	public static Vector3 GetWallContactPoint(){
		return wallContactPoint;
	}
	public static float GetWallAngle(){
		return wallAngle;
	}
	public static Vector3 GetTerrainContactPoint(){
		return terrainContactPoint;
	}
}
