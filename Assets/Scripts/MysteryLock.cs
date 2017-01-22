using UnityEngine;
using System.Collections;
using NewtonVR;

public class MysteryLock : MonoBehaviour {
	public GameObject mysteryLock;
	public GameObject mysteryKey;
	private NVRInteractableItem interactableScriptKey;
	public GameObject LeftHand;
	public GameObject RightHand;
	private Vector3 keyPosition;
	private Vector3 xPosition = new Vector3 (-0.006f, 0, 0);
	private Vector3 keyRotation = new Vector3 (0, -90, 90);

	void Start () {
		keyPosition = this.gameObject.transform.position;
		interactableScriptKey = mysteryKey.GetComponent<NVRInteractableItem> ();
	}


	void OnTriggerEnter (Collider collider) {	
		if(collider.gameObject == mysteryKey) {
			if (LeftHand.GetComponent<NVRHand>().CurrentlyInteracting == interactableScriptKey) {
				LeftHand.GetComponent<NVRHand>().EndInteraction(interactableScriptKey);
				SnapIn ();
			}
			if (RightHand.GetComponent<NVRHand>().CurrentlyInteracting == interactableScriptKey) {
				RightHand.GetComponent<NVRHand>().EndInteraction(interactableScriptKey);
				SnapIn ();
			}
		}
	}

	void SnapIn() {
		Destroy(mysteryKey.GetComponent<Rigidbody>());
		mysteryKey.transform.position = keyPosition;
		mysteryKey.transform.position += xPosition;
		mysteryKey.transform.localEulerAngles = keyRotation;
		mysteryKey.transform.parent = mysteryLock.transform;
		mysteryKey.GetComponent<NVRInteractableItem> ().enabled = false;
		mysteryLock.GetComponent<MysteryLockOpener> ().keyCount += 1;
		if (mysteryLock.GetComponent<MysteryLockOpener> ().keyCount >= 4) {
			mysteryLock.GetComponent<MysteryLockOpener> ().OpenDoor ();
		}
	}
}
