using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour {
	private Quaternion startRotation;
	private Vector3 startPosition;
	private float baseY;
	private float diffRotate = 2.5f;
	private GameObject parentObj;
	//private float distance = 7f;
	public static float cameraScale = 7;
	public static List<GameObject> furnitureInScene = new List<GameObject> ();
	public static bool isFurnitureCollision;
	public static bool hasSelectFurniture = false;
	public UIControl uiControl;
	public string furniturePath;
	public bool ceilingFurniture = false;
	public bool wallFurniture = false;
	public bool lockHight = false;
	public bool editMode = true;
	public bool isRotate = false;
	public bool CW;

	// Use this for initialization
	void Start () {
		//set Rigibody
		parentObj = GameObject.Find ("CenterEyeAnchor");
		Rigidbody rigi = gameObject.GetComponent<Rigidbody> ();
		if (rigi == null) {
			gameObject.AddComponent<Rigidbody> ();
			rigi = gameObject.GetComponent<Rigidbody> ();
			rigi.centerOfMass = Vector3.zero;
		}
		transform.RotateAround (transform.position, Vector3.zero, 0);

		rigi.useGravity = false;	
		rigi.mass = float.MaxValue;
		MergeMesh ();
		//editMode = true;
		gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		transform.localScale = transform.localScale / cameraScale;
		//GetComponent<Rigidbody> ().freezeRotation = true;
		startRotation = transform.rotation;
		startPosition = transform.localPosition;
		baseY = startRotation.eulerAngles.y;
		//startPosition.x = 0;

		//gameObject.layer = LayerMask.NameToLayer ("Ignore Raycast");
	}
	//code run after Update()
	void LateUpdate(){
		if (editMode) {
			Vector3 angle = startRotation.eulerAngles;
			if (CW) {
				GetComponent<Transform> ().eulerAngles = new Vector3 (angle.x, angle.y + diffRotate, angle.z);
				//transform.rotation = transform.rotation * Quaternion.Euler (0, diffRotate, 0);
			} else {
				GetComponent<Transform> ().eulerAngles = new Vector3 (angle.x, angle.y - diffRotate, angle.z);
			}

			if (!isRotate) {
				transform.rotation = startRotation;
			} else {
				Vector3 anglex = transform.eulerAngles;
				startRotation = Quaternion.Euler (startRotation.eulerAngles.x, anglex.y, startRotation.eulerAngles.z);
			}
			transform.localPosition = startPosition;
			Vector3 gobalPosition;
			/*
			//old change position when edit
			Vector3 gobalPosition = transform.position;
			gobalPosition = new Vector3 (gobalPosition.x, 0, gobalPosition.z);
			*/
			if (wallFurniture) {
				Vector3 tmp = EyePointer.GetWallContactPoint ();
				if (lockHight) {
					gobalPosition = new Vector3 (tmp.x, 0, tmp.z);
				} else {
					gobalPosition = new Vector3 (tmp.x, tmp.y,tmp.z-0.06f);
				}
				startRotation = Quaternion.Euler (startRotation.eulerAngles.x, EyePointer.GetWallAngle()+baseY, startRotation.eulerAngles.z);
			} else if (ceilingFurniture) {
				gobalPosition = EyePointer.GetCeilingContactPoint ();
			}else {
				//ground furniture
				Vector3 tmp = -parentObj.transform.forward*2;
				gobalPosition = new Vector3 (EyePointer.GetTerrainContactPoint ().x+tmp.x, EyePointer.GetTerrainContactPoint ().y, EyePointer.GetTerrainContactPoint ().z+tmp.z);
			}
			transform.position = gobalPosition;
		} else {
			transform.rotation = startRotation;
		}
	}

	void OnCollisionEnter(Collision collision){
		if (gameObject.tag.Equals("Adding_Furniture") && (collision.gameObject.tag.Equals ("Furniture") ||(collision.gameObject.tag.Equals ("Wall")) && !wallFurniture)) {
			isFurnitureCollision = true;
			//Debug.Log ("Enter-IF");
		}/*else if(collision.gameObject.tag.Equals("index") && gameObject.tag.Equals("Furniture") && !hasSelectFurniture){
			//show furniture menu
			hasSelectFurniture = true;
			EnableEditMode (true);
			Debug.Log("Menu touch");
		}*/

	}
	void OnCollisionStay(Collision collision){
		if (gameObject.tag.Equals("Adding_Furniture") && (collision.gameObject.tag.Equals ("Furniture") ||(collision.gameObject.tag.Equals ("Wall")) && !wallFurniture)) {
			isFurnitureCollision = true;
		}
	}
	void OnCollisionExit(Collision collision){
		if (gameObject.tag.Equals("Adding_Furniture") && (collision.gameObject.tag.Equals ("Furniture") ||collision.gameObject.tag.Equals ("Wall"))) {
			isFurnitureCollision = false;
		}
	}

	public void EnableEditMode(bool b){
		if (b) {
			hasSelectFurniture = true;
			gameObject.tag = "Adding_Furniture";
			parentObj = GameObject.Find ("CenterEyeAnchor");

			Vector3 throwPos = parentObj.transform.position + parentObj.transform.forward ;
			//Debug.Log(throwPos);
			transform.parent = parentObj.transform;
			startPosition = parentObj.transform.InverseTransformPoint(throwPos);

			gameObject.layer = LayerMask.NameToLayer ("Ignore Raycast");
		} else {
			gameObject.tag = "Furniture";
			transform.parent = null;

			gameObject.layer = LayerMask.NameToLayer ("Default");
		}
		Debug.Log (b);
		editMode = b;
		if (uiControl == null) {
			uiControl = GameObject.Find ("LMHeadMountedRig").GetComponent<UIControl>();
		}
		uiControl.SetActiveEditFurnitureButton (b,wallFurniture);
	}

	//my code so handsome
	private void MergeMesh(){
		Quaternion oldRotate = transform.rotation;
		Vector3 oldPosition = transform.position;
		Vector3 oldScale = transform.localScale;

		transform.rotation = Quaternion.identity;
		transform.position = Vector3.zero;
		if (transform.parent == null)
			transform.localScale = Vector3.one;
		else
			transform.localScale = Vector3.one / cameraScale;

		MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter> ();
		CombineInstance[] combine = new CombineInstance[meshFilters.Length];
		for(int i=0;i<meshFilters.Length;i++) {
			combine [i].mesh = meshFilters [i].mesh;
			combine [i].transform = meshFilters [i].transform.localToWorldMatrix;
			//meshFilters [i].gameObject.SetActive (false);
		}
		MeshFilter parentMesh = transform.GetComponent<MeshFilter> ();
		if (parentMesh == null) {
			gameObject.AddComponent<MeshFilter>();
			gameObject.AddComponent<MeshRenderer>();
		}
		transform.GetComponent<MeshFilter> ().mesh = new Mesh ();
	
		transform.GetComponent<MeshFilter> ().mesh.CombineMeshes (combine);
		//Debug.Log (meshFilters.Length);
		//transform.gameObject.SetActive (true);
		gameObject.AddComponent<BoxCollider>();
		Destroy (transform.GetComponent<MeshFilter>());
		Destroy (transform.GetComponent<MeshRenderer>());

		transform.rotation = oldRotate;
		transform.position = oldPosition;
		transform.localScale = oldScale;
	}
}
