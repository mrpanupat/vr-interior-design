using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour {
	public GameObject wall;
	public Texture test;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//change texture
		GetComponent<Renderer>().material.SetTexture("_DiffuseMapSpecA",test);
	}
}
