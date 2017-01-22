using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

	public bool handHovering = false;
	public GameObject LeftHandPrint;
	public GameObject RightHandPrint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter(Collider collider) {
		if (collider.gameObject == LeftHandPrint || collider.gameObject == RightHandPrint) {
			handHovering = true;
		}
	}

	private void OnTriggerExit(Collider collider) {
		if (collider.gameObject == LeftHandPrint || collider.gameObject == RightHandPrint) {
			handHovering = false;
		}
	}
}
