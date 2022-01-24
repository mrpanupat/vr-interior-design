using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RotateButton : MonoBehaviour ,IPointerDownHandler ,IPointerUpHandler{
	public bool CW;
	// Use this for initialization
	void Start () {
		/*
		GetComponent<Button> ().OnPointerDown (() => {
			
		});

		GetComponent<Button> ().OnPointerUp (() => {
			GameObject furniture = GameObject.FindGameObjectWithTag("Adding_Furniture");
			furniture.GetComponent<Furniture>().isRotate = false;
		});*/
	}

	public void OnPointerDown(PointerEventData eventData){
		GameObject furniture = GameObject.FindGameObjectWithTag("Adding_Furniture");
		furniture.GetComponent<Furniture>().CW = CW;
		furniture.GetComponent<Furniture>().isRotate = true;
		furniture.GetComponent<Rigidbody> ().freezeRotation = false;
		//Debug.Log ("What is this");
	}

	public void OnPointerUp(PointerEventData eventData){
		GameObject furniture = GameObject.FindGameObjectWithTag("Adding_Furniture");
		furniture.GetComponent<Furniture>().isRotate = false;
	}

}
