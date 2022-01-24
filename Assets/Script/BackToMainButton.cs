using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMainButton : MonoBehaviour {
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
				SceneManager.LoadScene("SplashScreen");
			});
			DontSaveButton.GetComponent<Button> ().onClick.AddListener (() => {
				SceneManager.LoadScene("SplashScreen");
			});
		});
	}
}
