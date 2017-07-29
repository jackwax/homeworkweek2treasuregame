using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour {


	public Transform target;

	CharacterController cc;

	public float speed = 2;

	// Use this for initialization
	void Start () {

		cc = GetComponent<CharacterController> ();

		this.transform.position = target.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Mouse X") < 0) {
			transform.Rotate (Vector3.up * -speed);
		}
		if (Input.GetAxis ("Mouse X") > 0) {
			transform.Rotate (Vector3.up * speed);
		}

		if (Input.GetAxis ("Mouse Y") > 0) {
			transform.Rotate(new Vector3 (1,0,0) * -speed);
		}

		if (Input.GetAxis ("Mouse Y") < 0) {
			transform.Rotate(new Vector3 (1,0,0) * speed);
		}

		
	}
}
