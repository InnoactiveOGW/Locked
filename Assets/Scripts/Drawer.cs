using UnityEngine;
using System.Collections;
using NewtonVR;


public class Drawer : MonoBehaviour {
	public bool locked = true;
	public GameObject key;
	private AudioSource audio;
	private NVRInteractableItem drawerScript;
	private NVRInteractableItem keyScript;
	private ConfigurableJoint joint;
	private HingeJoint keyJoint;
	private Vector3 jointAxis;
	private Vector3 jointAnchor;
	
	void Start() {
		drawerScript = this.gameObject.GetComponent<NVRInteractableItem>();
		jointAxis = new Vector3 (-1, 0, 0);
	}

	void Update() {
		if (!locked) {
			drawerScript.enabled = true;
		} else if (locked) {
			drawerScript.enabled = false;
		}
	}
			
	void OnTriggerEnter (Collider collider) {	
		if(collider.gameObject == key) {
			audio = this.gameObject.GetComponent<AudioSource> ();
			if (locked) {
				audio.Play();
			}
			/*key.gameObject.AddComponent<HingeJoint> ();
			keyJoint = key.gameObject.GetComponent<HingeJoint> ();
			keyJoint.anchor = jointAnchor;
			keyJoint.axis = jointAxis;
			keyScript = key.GetComponent<NVRInteractableItem> ();
			keyScript.enabled = false;
			key.transform.parent = this.transform;*/
			joint = this.gameObject.GetComponentInParent<ConfigurableJoint> ();
			joint.yMotion = ConfigurableJointMotion.Limited;
			locked = false;
		}
	}
}