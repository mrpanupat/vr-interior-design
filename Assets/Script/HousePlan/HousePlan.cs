using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousePlan : MonoBehaviour {
	private int gapSize = 50;
	// Use this for initialization
	void Start () {
		GameObject dotImageResource = Resources.Load ("Image/DotImage",typeof(GameObject)) as GameObject;
		for (int i = 0; i < 9; i++) {
			for (int j = 0; j < 9; j++) {
				GameObject dotImage = Instantiate (dotImageResource,this.transform);
				dotImage.GetComponent<RectTransform> ().localPosition = new Vector3(-200+j*gapSize,200-i*gapSize,0);
				dotImage.GetComponent<RectTransform> ().localScale = Vector3.one;
				dotImage.GetComponent<DotScript> ().dotIndex = (j + 1) + (i * 9);
			}
		}

	}
}
