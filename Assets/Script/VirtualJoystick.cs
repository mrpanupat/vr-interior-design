using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystick : MonoBehaviour, IDragHandler,IPointerUpHandler,IPointerDownHandler
{
	private Image bgImg;
	private Image joystickImg;
	private Vector3 inputVector;
	private float speed = 0.2f;
	private Vector3 currentPos;
	public GameObject vrCamera;
	void Start()
	{
		bgImg = GetComponent<Image> ();
		joystickImg = transform.GetChild(0).GetComponent<Image>();
	}
	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform
			, ped.position
			, ped.pressEventCamera
			, out pos)) 
		{
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
			//Debug.Log (pos.x*2 + " "+ pos.y*2);
			inputVector = new Vector3 (pos.x*2 ,0,pos.y*2);
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

			Vector3 oldPosition = vrCamera .transform.position;
			Vector3 tranformValue = vrCamera.transform.GetChild (1).forward * speed * Vertical ();
			tranformValue = tranformValue + vrCamera.transform.GetChild (1).right * speed * Horizontal ();

			float newX = oldPosition.x + tranformValue.x;
			float newY = oldPosition.y; // not adjust hight
			float newZ = oldPosition.z + tranformValue.z;
			if (newX < 10)
				newX = 10;
			else if (newX > 90)
				newX = 90;
			if (newZ > 0)
				newZ = 0;
			else if (newZ < -80)
				newZ = -80;
			Vector3 newPos = new Vector3 (newX, newY, newZ);
			vrCamera.GetComponent<Transform> ().position = newPos;
			joystickImg.rectTransform.anchoredPosition =
				new Vector3 (inputVector.x * (bgImg.rectTransform.sizeDelta.x/2)
					, inputVector.z * (bgImg.rectTransform.sizeDelta.y/2));
			
		}
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
	}


	public virtual void OnPointerUp(PointerEventData ped)
	{
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	public float Horizontal()
	{
		if (inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis ("Horizontal");
	}

	public float Vertical()
	{

		if (inputVector.z != 0)
			return inputVector.z;
		else
			return Input.GetAxis ("Vertical");
	}

}﻿