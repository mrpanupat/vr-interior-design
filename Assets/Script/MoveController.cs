using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MoveController : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler {
	public bool isFront;
	public bool isBack;
	public bool isLeft;
	public bool isRight;
	public float speed=0.2f;
	public GameObject vrCamera;
	// Use this for initialization
	void Start () {
		
	}
	public virtual void OnDrag(PointerEventData ped)
	{
		Vector3 oldPosition = vrCamera .transform.position;
		Vector3 tranformValue = Vector3.zero;
		if (isFront) {
			tranformValue = vrCamera.transform.forward *speed;
		} else if (isBack) {
			tranformValue = vrCamera.transform.forward *speed;
		}

		if (isLeft) {
			tranformValue += vrCamera.transform.GetChild(1).forward *speed;
		} else if (isRight) {

		}
			
		float newX = oldPosition.x+tranformValue.x;
		float newY = oldPosition.y; // not adjust hight
		float newZ = oldPosition.z+tranformValue.z;
		Vector3 newPos = new Vector3 (newX,newY,newZ);
		vrCamera.GetComponent<Transform>().position = newPos;
	}
	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
	}
		
	public virtual void OnPointerUp(PointerEventData ped)
	{
		
	}
}
