using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditFurnitureButton : MonoBehaviour {
	public GameObject selectFurniture;
	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (() => {
			selectFurniture.GetComponent<Furniture>().EnableEditMode(true);
		});
	}
}
