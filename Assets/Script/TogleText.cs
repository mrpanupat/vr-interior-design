using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogleText : MonoBehaviour {
	public int timer = 0;
	private CanvasRenderer rd;
	// Use this for initialization
	void Start () {
		rd = GetComponent<CanvasRenderer> ();
		rd.SetAlpha (0);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (rd.GetAlpha ());
		if (timer <= 0)
			rd.SetAlpha (0);
		else {
			rd.SetAlpha (1);
			timer = timer -1;
		}
	}
}