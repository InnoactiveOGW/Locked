using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {
	//Grip Button
	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	private bool gripButtonDown = false;
	private bool gripButtonUp = false;
	private bool gripButtonPressed = false;

	//Trigger Button
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private bool triggerButtonDown = false;
	private bool triggerButtonUp = false;
	private bool triggerButtonPressed = false;

	private SteamVR_Controller.Device controller {get { return SteamVR_Controller.Input((int)trackedObj.index); } }
	private SteamVR_TrackedObject trackedObj;

	HashSet<InteractableItem> objectsHoveringOver = new HashSet<InteractableItem>();

	private InteractableItem closestItem;
	private InteractableItem interactingItem;

	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller == null) {
			Debug.Log("Controller not initialized");
			return;
		}

		gripButtonDown = controller.GetPressDown(gripButton);
		gripButtonUp = controller.GetPressUp(gripButton);
		gripButtonPressed = controller.GetPress(gripButton);

		triggerButtonDown = controller.GetPressDown(triggerButton);
		triggerButtonUp = controller.GetPressUp(triggerButton);
		triggerButtonPressed = controller.GetPress(triggerButton);

		if (gripButtonDown) {
			Debug.Log("Grip Button was just pressed");
		}
		if (gripButtonUp) {
			Debug.Log("Grip Button was just unpressed");
		}
		if (triggerButtonDown) {
			Debug.Log("Trigger Button was just pressed");
			float minDistance = float.MaxValue;
			float distance;
			foreach (InteractableItem item in objectsHoveringOver) {
				distance = (item.transform.position - transform.position).sqrMagnitude;

				if (distance < minDistance) {
					minDistance = distance;
					closestItem = item;
				}
			}

			interactingItem = closestItem;

			if (interactingItem) {
				if (interactingItem.IsInteracting ()) {
					interactingItem.EndInteraction (this);
				}
				interactingItem.BeginInteraction (this);
			}
			//pickup.transform.parent = this.transform;
			//pickup.GetComponent<Rigidbody> ().useGravity = false;
		}
		if (triggerButtonUp && interactingItem != null) {
			Debug.Log("Trigger Button was just unpressed");
			interactingItem.EndInteraction (this);
			//pickup.transform.parent = null;
			//pickup.GetComponent<Rigidbody> ().useGravity = true;
		}
	}

	private void OnTriggerEnter(Collider collider) {
		Debug.Log ("Trigger entered");
		InteractableItem collidedItem = collider.GetComponent<InteractableItem> ();
		if (collidedItem) {
			objectsHoveringOver.Add (collidedItem);
		}
		//pickup = collider.gameObject;
	}

	private void OnTriggerExit(Collider collider) {
		Debug.Log ("Trigger exit");
		InteractableItem collidedItem = collider.GetComponent<InteractableItem> ();
		if (collidedItem) {
			objectsHoveringOver.Remove (collidedItem);
		}
		//pickup = null;
	}
}
