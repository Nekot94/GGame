using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public enum RotationAxis
	{
		MouseX, 
		MouseY,
		MouseXAndY
	}
	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;

	public RotationAxis axes = RotationAxis.MouseX;

	private float _rotationX = 0;

	private float _maxX = -45f;
	private float _maxY = 45f;

	void Start () {
		
	}

	void Update () {
		if (axes == RotationAxis.MouseX) {
			transform.Rotate (0,Input.GetAxis("Mouse X") * sensitivityHor, 0);
		} else if (axes == RotationAxis.MouseY) {
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp (_rotationX, _maxX, _maxY);
			transform.localEulerAngles = new Vector3 (_rotationX, transform.localEulerAngles.y, 0);
		} else if (axes == RotationAxis.MouseXAndY) {
			float rotationY = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * sensitivityHor;
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp (_rotationX, _maxX, _maxY);
			transform.localEulerAngles = new Vector3 (_rotationX, transform.localEulerAngles.y, 0);
			
		}
	}
}
