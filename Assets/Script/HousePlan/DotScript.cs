using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotScript : MonoBehaviour {
	private static DotScript start;
	private static DotScript end;
	private static DotScript[] dotList = new DotScript[81];
	//private static List<GameObject> lineList = new List<GameObject> ();
	public static List<EdgeData> list = new List<EdgeData>();
	public static List<EdgeData> oldList = new List<EdgeData>();
	public static UIControl uiControl;
	public static bool isWrite = true;
	public int dotIndex;

	void Start(){
		dotList [dotIndex-1] = this;
		if (uiControl == null) {
			uiControl = GameObject.Find ("LMHeadMountedRig").GetComponent<UIControl>();
		}
	}

	void OnCollisionEnter(Collision collision) {
		//only index finger can touch dot
		if(collision.gameObject.tag.Equals("index")&&isWrite&&start!=null){
			end = this;
			EdgeData inputEdge = new EdgeData (start.dotIndex, end.dotIndex);
			//2nd dot must in 4 dot around 1st dot
			if ((inputEdge.getEnd() - inputEdge.getStart() == 1 && inputEdge.getStart()%9 != 0)|| inputEdge.getEnd() - inputEdge.getStart() == BluePrintData.ROOM_X_LENGTH) {
				//EdgeData inputEdge = new EdgeData (start.dotIndex, end.dotIndex);
				//if edge exist don't add it
				bool isEdgeExist = false;
				//Debug.Log (list.Count);
				list.ForEach (delegate(EdgeData edge) {
					if (edge.Equal (inputEdge)) {
						isEdgeExist = true;
					}
				});
				//Debug.Log (isEdgeExist);
				if (!isEdgeExist) {
					list.Add (inputEdge);
					//Debug.Log (start.GetComponent<RectTransform> ().localPosition);
					DrawLine (start, end,Color.red, 0);
					start = null;
					end = null;
				}
			}
		}
	}
	void OnCollisionExit(Collision collision){
		if(collision.gameObject.tag.Equals("index")&&isWrite){
			start = this;
		}
	}

	public static void DrawLine(DotScript s, DotScript e, Color color, float duration = 0.2f)
	{
		GameObject line = Resources.Load ("Image/Line",typeof(GameObject)) as GameObject;
		Debug.Log (uiControl);
		line = Instantiate (line,uiControl.lineList.transform);

		Vector3 starta;
		if (s.dotIndex < e.dotIndex) {
			starta = s.GetComponent<RectTransform> ().localPosition;
			line.name = s.dotIndex + " " + e.dotIndex;
		} else {
			starta = e.GetComponent<RectTransform> ().localPosition;
			line.name = e.dotIndex + " " + s.dotIndex;
		}
		//Debug.Log (starta);
		if (Mathf.Abs (s.dotIndex - e.dotIndex) == 1) {
			line.GetComponent<Transform> ().localRotation = Quaternion.Euler (0, 0, 0);
			line.GetComponent<Transform> ().localPosition = starta + new Vector3(25,0,0);
		} else {
			line.GetComponent<Transform> ().localRotation = Quaternion.Euler (0, 0, 90);
			line.GetComponent<Transform> ().localPosition = starta + new Vector3(0,-25,0);;
		}

		line.GetComponent<Transform> ().localScale = new Vector3 (0.5f, 0.07f, 0.1f);
	}

	public static void ComfirmRoom(){
		oldList = new List<EdgeData> (list);
		BluePrintData.CreateArrayFromList (list);
		BluePrintData.CreateRoom ();
	}

	public static void RemoveEdge(EdgeData e){
		EdgeData deleteEdge = null;
		list.ForEach (delegate(EdgeData edge) {
			if (edge.Equal (e)) {
				deleteEdge = edge;
			}
		});
		if (deleteEdge != null) {
			list.Remove(deleteEdge);
		}
	}

	public static DotScript FindDot(int index){
		return dotList [index-1];
	}

	public static void ClearAll(){
		list.Clear ();
		foreach (Transform child in uiControl.lineList.transform) {
			Destroy (child.gameObject);
		}
	}

	public static void RestoreOldLine(){
		ClearAll ();
		oldList.ForEach(delegate(EdgeData edge) {

			DotScript start = FindDot(edge.getStart());
			DotScript end = FindDot(edge.getEnd());

			DrawLine (start, end,Color.red, 0);
		});
		list = new List<EdgeData> (oldList);
	}
}
