using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour {	
	// Update is called once per frame
	void OnCollisionEnter(Collision collision) {
		/*
		Debug.Log ("Linear touch");
		//collision.contacts;
		if (DotScript.isWrite == false) {
			int start = int.Parse (name.Split(' ')[0]);
			int end = int.Parse (name.Split (' ')[1]);
			Debug.Log (start + " " + end);
			DotScript.RemoveEdge (new EdgeData (start, end));
			Destroy (this.gameObject);
		}*/

		foreach (ContactPoint contact in collision.contacts) {
			//Debug.Log (contact.otherCollider.name);
			if (contact.otherCollider.tag.Equals("index") && !DotScript.isWrite) {
				int start = int.Parse (name.Split(' ')[0]);
				int end = int.Parse (name.Split (' ')[1]);
				//Debug.Log (start + " " + end);
				DotScript.RemoveEdge (new EdgeData (start, end));
				Destroy (this.gameObject);
				break;
			}
		}
	}
}
