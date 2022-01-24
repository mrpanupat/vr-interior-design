using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionButton : MonoBehaviour {
	public GameObject togleText;
	// Use this for initialization
	void Start () {
		GetComponent<Button> ().onClick.AddListener (() => {
			SaveLoad.SaveScene();
			togleText.GetComponent<Image>().sprite = Resources.Load("Image/SaveSuccess_90",typeof(Sprite)) as Sprite;
			togleText.GetComponent<TogleText>().timer = 90;
		});
	}
}
