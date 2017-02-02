using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour {
	public float speed = 9.0f;
	public float gravity = -9.8f;
    public float jumpSpeed = 15.0f;
    public float minFall = -1.5f;

    private float _vertSpeed;

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
	
        if (_characterController.isGrounded) {
            if (Input.GetButtonDown("Jump")) {
                _vertSpeed = jumpSpeed;
            }
            else {
                _vertSpeed = minFall;
            }
        } else {
            _vertSpeed += gravity * 5 * Time.deltaTime;
        }

        movement.y = _vertSpeed * Time.deltaTime;

		movement = transform.TransformDirection (movement);
		_characterController.Move (movement);


		//transform.Translate (deltaX * speed * Time.deltaTime, 0, 
		//	deltaZ * speed * Time.deltaTime);
	}
}
