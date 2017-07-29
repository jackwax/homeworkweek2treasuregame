using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour {

	public float mouseSensitivity = 250.0f;
	public float clampAngle = 80.0f;

	private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the right/x axis

	private float speed = 0.25f;

	public bool isAscended= false;
	public bool isDescended = false;

	void Start ()
	{
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;

		isAscended = false;
		isDescended = false;

		this.transform.GetChild(0).position = this.transform.position;
	}

	void FixedUpdate(){
		this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}

	void Update ()
	{
		


		//if (Input.GetKeyUp (KeyCode.Space)) {
		//	transform.Translate (new Vector3 (0, speed* 10, 0));
		//}

		if (isDescended == true || isAscended == true) {


			if (isAscended == true) {
				this.transform.rotation = Quaternion.Euler (0, 180, 0);
	
				this.transform.Translate (new Vector3 (0, 0.25f, 0));

				this.transform.Rotate (0, 10f, 0);
			} else {

				this.transform.rotation = Quaternion.Euler (0, 0, 0);
				
				this.transform.Translate (new Vector3 (0, -0.25f, 0));
			}
		
		

			
			

		



		} else {
			if (Input.GetKey (KeyCode.W)) {
				transform.Translate(new Vector3 (0, 0, speed));
			}
			if (Input.GetKey (KeyCode.A)) {
				transform.Translate(new Vector3 (-speed, 0, 0));
			}
			if (Input.GetKey (KeyCode.D)) {
				transform.Translate(new Vector3 (speed, 0, 0));
			}
			if (Input.GetKey (KeyCode.S)) {
				transform.Translate(new Vector3 (0, 0, -speed));
			}
			if (transform.position.y > 1.5f || transform.position.y < 1.5f) {
				transform.position = new Vector3(transform.position.x , 1.5f, transform.position.z);
			}

			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = -Input.GetAxis ("Mouse Y");

			rotY += mouseX * mouseSensitivity * Time.deltaTime;
			rotX += mouseY * mouseSensitivity * Time.deltaTime;



			rotX = Mathf.Clamp (rotX, -clampAngle, clampAngle);

			Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0.0f);
			transform.rotation = localRotation;
		}


	}

	void OnCollisionEnter(Collision col){
		transform.Translate (Vector3.zero);
	}
}

