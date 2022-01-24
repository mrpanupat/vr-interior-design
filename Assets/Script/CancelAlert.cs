﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelAlert : MonoBehaviour {
	public GameObject alertPlane;
	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (() => {
			alertPlane.SetActive(false);
		});
	}

}
