using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmButton : MonoBehaviour {
	public GameObject cwButton;
	public GameObject ccwButton;
	public GameObject cancelButton;
	public GameObject furniture;
	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (() => {
			GameObject furniture = GameObject.FindGameObjectWithTag("Adding_Furniture");
			furniture.tag = "Furniture";
			//furniture.GetComponent<Rigidbody>().useGravity = false;
			furniture.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			furniture.GetComponent<Furniture>().EnableEditMode(false);

			Vector3 currentPosition = transform.position;
			//Debug.Log(currentPosition);
			furniture.transform.parent = null;
			//furniture.transform.position = currentPosition;

			//hide furniture rotate and confirm button
			transform.parent.gameObject.SetActive(false);
			cwButton.SetActive(false);
			ccwButton.SetActive(false);
			cancelButton.SetActive(false);

			Furniture.furnitureInScene.Add(furniture.gameObject);
			Furniture.hasSelectFurniture = false;
			if (SubMenuButton.lastClick != null) {
				SubMenuButton.lastClick.GetComponent<SubMenuButton> ().changeToDefaultImage ();
			}
		});
	}

	// Update is called once per frame
	void Update () {
		if (Furniture.isFurnitureCollision) {
			GetComponent<Button> ().interactable = false;
			transform.parent.gameObject.GetComponent<Image>().color = new Color(0.5f,0.5f,0.5f);
		} else {
			GetComponent<Button> ().interactable = true;
			transform.parent.gameObject.GetComponent<Image>().color = new Color(1f,1f,1f);
		}
	
	}
}
