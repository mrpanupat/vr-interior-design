using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseApplicationButton : MonoBehaviour {
	public GameObject alertPlane;
	public GameObject optionPlane;
	public GameObject saveButton;
	public GameObject DontSaveButton;
	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (() => {
			alertPlane.SetActive(true);
			optionPlane.SetActive(false);
			saveButton.GetComponent<Button> ().onClick.AddListener (() => {
				SaveLoad.SaveScene();
				Application.Quit ();
			});
			DontSaveButton.GetComponent<Button> ().onClick.AddListener (() => {
				Application.Quit ();
			});
		});
	}
}
