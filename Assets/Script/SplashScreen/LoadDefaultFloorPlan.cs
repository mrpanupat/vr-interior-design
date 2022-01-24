using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadDefaultFloorPlan : MonoBehaviour {
	public string number;
	public static string fileName;
	public static Scene shareScene;
	// Use this for initialization
	void Start () {
		SceneManager.sceneLoaded -= OnSceneLoaded;
		GetComponent<Button> ().onClick.AddListener (() => {
			SceneManager.LoadScene("House");

			Debug.Log ("Get in there");
			shareScene = SceneManager.GetSceneByName("House");
			fileName = "DefaultFloorPlan/" + number;
		});
	}

	private void OnSceneLoaded(Scene scene,LoadSceneMode mode){
		
	}

	void Update(){
		if (shareScene != null) {
			if(shareScene.isLoaded)
				SaveLoad.LoadScene ("DefaultFloorPlan/" + number);
		}
	}
}
