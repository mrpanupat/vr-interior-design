using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseAbout : MonoBehaviour {
	public GameObject aboutUsPanel;
	public GameObject menuPanel;
	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (() => {
			aboutUsPanel.SetActive(false);
			menuPanel.SetActive(true);
		});
	}

}
