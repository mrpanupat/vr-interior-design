using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnClick : MonoBehaviour {
	public Texture test;
	public Texture white;
	public GameObject eiei;
	public GameObject LeftButton;
	public GameObject Button;
	public GameObject RightButton;
	// Use this for initialization
	void Start () {
		
		Button.GetComponent<Button> ().onClick.AddListener (() => {
			eiei.GetComponent<Renderer> ().material.SetTexture ("_DiffuseMapTransA", white);
			Debug.Log(eiei.GetComponent<Renderer> ().material.GetTexture("_DiffuseMapTransA").ToString());
			//for(int i=0;i<HouswMainScript.wallList.Length;i++){
			//	HouswMainScript.wallList [i].GetComponent<Renderer> ().material.SetTexture ("_DiffuseMapSpecA", test);
			//}
		});

		LeftButton.GetComponent<Button> ().onClick.AddListener (() => {
			eiei.GetComponent<Renderer> ().material.SetTexture ("_DiffuseMapTransA", test);
			Debug.Log(eiei.GetComponent<Renderer> ().material.GetTexture("_DiffuseMapTransA").ToString());
			//for(int i=0;i<HouswMainScript.wallList.Length;i++){
			//	HouswMainScript.wallList [i].GetComponent<Renderer> ().material.SetTexture ("_DiffuseMapSpecA", test);
			//}
		});

		RightButton.GetComponent<Button> ().onClick.AddListener (() => {
			eiei.GetComponent<Renderer> ().material.SetTexture ("_DiffuseMapTransA", test);
			Debug.Log(eiei.GetComponent<Renderer> ().material.GetTexture("_DiffuseMapTransA").ToString());
			//for(int i=0;i<HouswMainScript.wallList.Length;i++){
			//	HouswMainScript.wallList [i].GetComponent<Renderer> ().material.SetTexture ("_DiffuseMapSpecA", test);
			//}
		});
	}
}
