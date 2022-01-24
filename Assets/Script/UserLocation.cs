using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserLocation : MonoBehaviour {
	public GameObject mainCamera;
	public GameObject centerEye;
	// Update is called once per frame
	void Update () {
		transform.localPosition = WorldLocationToPlanLocation (mainCamera.transform.position);
		RectTransform rectTransform = GetComponent<RectTransform>();
		rectTransform.localRotation = Quaternion.Euler(0, 0, -WorldRotationToPlanRotation(centerEye.transform.rotation));
		//Debug.Log (WorldLocationToPlanLocation (mainCamera.transform.position));
	}

	private Vector3 WorldLocationToPlanLocation(Vector3 worldLocation){
		float planX = -200 + (worldLocation.x-10)*5;
		float planY = 200 + worldLocation.z*5;
		return new Vector3(planX,planY,0);
	}
	private float WorldRotationToPlanRotation(Quaternion worldRotation){
		return worldRotation.eulerAngles.y;
	}
}
