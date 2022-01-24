using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeToHouseScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (() => {
			LoadDefaultFloorPlan.fileName = "";
			SceneManager.LoadScene("House");
		});
	}
}
