using UnityEngine;
using System.Collections;

public class TriggerDrawer : MonoBehaviour {
	public bool open = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (open) {
			//this.GetComponent<Rigidbody> ().AddForce (10, 0, 0);
			this.GetComponent<Rigidbody>().isKinematic = false;
			this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,3);
		}
		if (!open) {
			this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-3);
		}
	}
}
