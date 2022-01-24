using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWallTexture : MonoBehaviour {
	public Texture texture;
	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (() => {
			for(int i=0;i<BluePrintData.wallList.Length;i++){
				GameObject wall = BluePrintData.wallList [i];
				for(int j=0;j<4;j++){
					wall.transform.GetChild(j).GetComponent<Renderer>().material.SetTexture ("_DiffuseMapSpecA", texture);
					BluePrintData.wallTexture = texture;
				}
			}
		});
	}
}
