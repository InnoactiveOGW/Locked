using UnityEngine;
using System.Collections;

public class BookStop : MonoBehaviour {

	public GameObject book;
	public GameObject door1;
	public GameObject door2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter (Collider collider) {
		//collider.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		if (collider.gameObject == book) {
			OpenDoor (door1);
			OpenDoor (door2);
		}
	}

	void OpenDoor (GameObject door) {
		door.GetComponent<Rigidbody> ().isKinematic = false;
		door.GetComponent<HingeJoint> ().useMotor = true;
	}
}
