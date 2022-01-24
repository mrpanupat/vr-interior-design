using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseMainScript : MonoBehaviour {
	private bool loaded = false;
	// Use this for initialization
	//public GameObject instantiateWall;
	void Start () {
		BluePrintData.wallTexture= Resources.Load ("Image/HouseWallpaper/Wall_01", typeof(Texture)) as Texture;
		DotScript.oldList.Clear ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit ();
		}

		if (LoadDefaultFloorPlan.shareScene.isLoaded&&!loaded&&!LoadDefaultFloorPlan.fileName.Equals("")) {
			Debug.Log (LoadDefaultFloorPlan.fileName);
			SaveLoad.LoadScene (LoadDefaultFloorPlan.fileName);
			loaded = true;
		}
	}



	void printList(){
		for (int i = 0; i < BluePrintData.GetSize(); i++) {
			EdgeData tmp = BluePrintData.GetValue (i);
			Debug.Log (tmp.getStart()+" "+tmp.getEnd());
		}
	}
}
