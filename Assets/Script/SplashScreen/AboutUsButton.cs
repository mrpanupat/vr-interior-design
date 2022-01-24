using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutUsButton : MonoBehaviour {
	public GameObject aboutUsPanel;
	public GameObject menuPanel;
	public GameObject chooseDefaultPanel;
	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (() => {
			aboutUsPanel.SetActive(true);
			menuPanel.SetActive(false);
			chooseDefaultPanel.SetActive(false);
		});
	}
}
