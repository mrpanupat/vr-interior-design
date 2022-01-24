using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("Update");
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			ChangeToHouseScene ();
		}
	}

	void ChangeToHouseScene(){
		List<EdgeData> x = new List<EdgeData>();
		x.Add (new EdgeData (1, 2));
		x.Add (new EdgeData (3, 2));
		x.Add (new EdgeData (3, 4));
		x.Add (new EdgeData (4, 5));
		x.Add (new EdgeData (5, 6));

		x.Add (new EdgeData (1, 7));
		x.Add (new EdgeData (7, 13));
		x.Add (new EdgeData (13, 19));

		x.Add (new EdgeData (6, 12));
		x.Add (new EdgeData (12, 18));
		x.Add (new EdgeData (18, 24));

		x.Add (new EdgeData (19, 20));
		x.Add (new EdgeData (20, 21));
		x.Add (new EdgeData (21, 22));
		x.Add (new EdgeData (22, 23));
		x.Add (new EdgeData (23, 24));
		BluePrintData.CreateArrayFromList (x);

		Debug.Log ("Change game");
		SceneManager.LoadScene ("House");
	}
}
