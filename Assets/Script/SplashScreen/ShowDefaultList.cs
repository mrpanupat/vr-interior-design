using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDefaultList : MonoBehaviour {
	public GameObject defaultPlan;
	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (() => {
			if(defaultPlan.activeInHierarchy){
				defaultPlan.SetActive(false);
			}else{
				defaultPlan.SetActive(true);
			}
		});
	}
}
