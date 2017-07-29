using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	public GameObject frontdoor;

	bool buttonPressed = false;

	public Button frontdoorbutton;
	public GameObject frontdoorbuttonobj;

	public GameObject VentureForthText;
	public GameObject DontLookBackText;



	public GameObject FirstClue;
	public GameObject SecondClue;
	public GameObject ThirdClue;


	public GameObject FakeTreasure;
	public GameObject Apple;

	public GameObject Ascension;
	public GameObject Decension;



	int timeleft;

	float seccounter;

	TextMesh FrontDoorText;
	public GameObject FirstClueText;
	public GameObject SecondClueText;
	public GameObject WarningText;
	public GameObject ThirdClueText;

	public GameObject player;

	public Text SpaceText;

	bool sendtospace;





	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;

		player = GameObject.Find ("player");


		frontdoor = GameObject.Find ("frontdoor");


		frontdoorbuttonobj = GameObject.Find ("FrontDoorButton");
		VentureForthText = GameObject.Find ("VentureForthText");
		DontLookBackText = GameObject.Find ("DontLookBackText");



		frontdoorbutton = frontdoorbuttonobj.GetComponent<Button>();
//
		FrontDoorText = GameObject.Find("FrontDoorText").GetComponent<TextMesh>();

		FirstClue = GameObject.Find ("FirstClue");
		FirstClueText = GameObject.Find ("FirstClueText");

		SecondClue = GameObject.Find ("SecondClue");
		FakeTreasure = GameObject.Find ("FakeTreasure");
		SecondClueText = GameObject.Find ("SecondClueText");
		WarningText = GameObject.Find ("WarningText");

		ThirdClue = GameObject.Find ("ThirdClue");
		ThirdClueText = GameObject.Find ("ThirdClueText");
		Apple = GameObject.Find ("apple");

		Ascension = GameObject.Find ("Ascension");
		Decension = GameObject.Find ("Decension");

		SpaceText = GameObject.Find ("SpaceText").GetComponent<Text> ();



//		frontdoorbutton.onClick.AddListener (OpenDoor);

		DontLookBackText.SetActive (false);
		VentureForthText.SetActive (false);
		FirstClueText.SetActive (false);

		SecondClueText.SetActive (false);
		WarningText.SetActive (false);
		Apple.SetActive (false);
	


		ThirdClueText.SetActive (false);
		ThirdClueText.SetActive (false);

		SpaceText.gameObject.SetActive (false);
		//print ("yeah");


		timeleft = 10;
		seccounter = 0;

	}
	
	// Update is called once per frame
	void Update () {
		frontdoorbutton.GetComponentInChildren<Text> ().text = "Submerging in: " + timeleft;


		seccounter += Time.deltaTime;

		if (seccounter >= 1) {
			timeleft -= (int) seccounter;
			seccounter = 0;

		}

		if (timeleft == 0) {
			buttonPressed = true;

			FrontDoorText.fontSize = 400;
			FrontDoorText.text = "Hallelujah";
		}


		if (buttonPressed) {

			//print ("yeah");
			frontdoor.GetComponent<Rigidbody> ().useGravity = true;
			
			frontdoor.GetComponent<Rigidbody> ().isKinematic = false;

			frontdoor.GetComponent<BoxCollider> ().enabled = false;

			frontdoorbuttonobj.SetActive (false);

			DontLookBackText.SetActive (true);
			VentureForthText.SetActive (true);
		}

			//frontdoor.GetComponent<Rigidbody>().

		if (Vector3.Distance(player.transform.position, FirstClue.transform.position) < 15f){
			FirstClueText.SetActive(true);
		}

		if (Vector3.Distance(player.transform.position, SecondClue.transform.position) < 5f){
			SecondClueText.SetActive(true);
			sendtospace = true;
			FirstClueText.SetActive (false);
			WarningText.SetActive (true);
			Apple.SetActive (true);
		}

		if (Vector3.Distance (player.transform.position, ThirdClue.transform.position) < 5f) {
			//print ("yeah");
			ThirdClueText.SetActive (true);
			SecondClueText.SetActive (false);
		}
			
		if (sendtospace) {
			FakeTreasure.transform.Translate(new Vector3(0,1f,0));
		}

		if (Vector3.Distance (player.transform.position, Ascension.transform.position) < 20f) {
			SpaceText.gameObject.SetActive (true);
			if(  Input.GetKeyUp (KeyCode.Space)){
				
			//print ("yeah");
			player.GetComponent<mouselook>().isAscended = true;
			SpaceText.text = "Advance";

			}
		}

		if (Vector3.Distance (player.transform.position, Decension.transform.position) < 20f) {
			SpaceText.gameObject.SetActive (true);
			if (Input.GetKeyUp (KeyCode.Space)) {
				//print ("yeah");
				player.GetComponent<mouselook> ().isDescended = true;
				SpaceText.text = "Wallow";
			}
		}

			//print(Vector3.Distance(player.transform.position, Ascension.transform.position));




		
	}

//	void OpenDoor(){
//		print ("yeah");
//		frontdoor.GetComponent<Rigidbody>().useGravity = true;
//
//		frontdoor.GetComponent<Rigidbody>().isKinematic = false;
//
//		frontdoor.GetComponent<BoxCollider> ().enabled = false;
//	}

}
