using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrintData : MonoBehaviour{
	public static readonly int ROOM_X_LENGTH=9;
	public static readonly int ROOM_Y_LENGTH=9;
	public static GameObject[] wallList;
	public static Texture wallTexture;
	private static EdgeData[] edgeArray;

	public static void CreateArrayFromList(List<EdgeData> x){
		edgeArray = x.ToArray();
	}
	public static EdgeData GetValue(int x){
		return edgeArray [x];
	}
	public static int GetSize(){
		if (edgeArray == null)
			return 0;
		return edgeArray.Length;
	}

	public static void clear(){
		edgeArray = null;
	}

	public static void CreateRoom(){
		DestroyWall ();
		List<GameObject> wallListTmp = new List<GameObject>();
		GameObject instantiateWall = Resources.Load ("Wall/Thick_Wall",typeof(GameObject)) as GameObject;
		instantiateWall.GetComponentInChildren<Renderer>().sharedMaterial.SetTexture ("_DiffuseMapSpecA", wallTexture);
		Vector3 prefabSize = instantiateWall.transform.GetChild(0).gameObject.GetComponent<Renderer>().bounds.size;

		for (int i = 0; i < BluePrintData.GetSize(); i++) {
			Quaternion prefabRotate = instantiateWall.transform.rotation;
			Vector3 prefabPosition = instantiateWall.transform.position;
			Vector3 tranPosition;
			if (BluePrintData.GetValue (i).getEnd () - BluePrintData.GetValue (i).getStart () == 1) {
				//not rotate
				float tranX = prefabSize.x * (BluePrintData.GetValue (i).getStart () % ROOM_X_LENGTH);
				float tranZ = -prefabSize.x * Mathf.Floor(BluePrintData.GetValue (i).getStart ()/ROOM_X_LENGTH);
				tranPosition = prefabPosition + new Vector3 (tranX, 0, tranZ);
			} else if (BluePrintData.GetValue (i).getEnd () - BluePrintData.GetValue (i).getStart () == ROOM_X_LENGTH) {
				float tranX = prefabSize.x * (BluePrintData.GetValue (i).getStart () - Mathf.Floor((BluePrintData.GetValue (i).getStart ()-1)/ROOM_X_LENGTH)*ROOM_X_LENGTH);
				float tranZ = -prefabSize.x * Mathf.Floor((BluePrintData.GetValue (i).getStart ()-1)/ROOM_X_LENGTH);
				tranPosition = prefabPosition + new Vector3 (tranX, 0, tranZ);
				tranPosition = tranPosition + new Vector3 (-5, 0, -5);
				prefabRotate = prefabRotate * Quaternion.Euler (0, 0, -90);
			} else {
				tranPosition = new Vector3 (0, 0, 0);
			}
			wallListTmp.Add(Instantiate(instantiateWall,tranPosition,prefabRotate));
		}
		wallList = wallListTmp.ToArray ();
	}

	public static void DestroyWall(){
		if (wallList != null) {
			foreach (GameObject wall in wallList) {
				GameObject.Destroy (wall);
			}
		}
	}
}
