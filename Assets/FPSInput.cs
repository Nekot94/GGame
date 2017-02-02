using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour {
	public float speed = 9.0f;
	public float gravity = -9.8f;

	private CharacterController _characterController;
	// Use this for initialization
	void Start () {
		_characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis("Horizontal");
		float deltaZ = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (deltaX * speed * Time.deltaTime, 0, 
			deltaZ * speed * Time.deltaTime);
		movement = Vector3.ClampMagnitude(movement, speed);
		movement.y = gravity;
		if (Input.GetButtonDown("Jump")){
			Debug.Log ("Гаджи n1");
		}
		movement = transform.TransformDirection (movement);
		_characterController.Move (movement);

		//transform.Translate (deltaX * speed * Time.deltaTime, 0, 
		//	deltaZ * speed * Time.deltaTime);
	}
}
