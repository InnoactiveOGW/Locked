using UnityEngine;
using System.Collections;
using NewtonVR;


public class KeyLock : MonoBehaviour {
	public bool locked = true;
	public bool hasLock = true;

	public GameObject key;
	private AudioSource audio;

	//for Drawers
	public GameObject drawer;
	public int motionAxis;
	private ConfigurableJoint joint;

	//for up to 2 Doors
	public GameObject door;
	public GameObject door2;
	private float minLimit;
	private float maxLimit;
	private float minLimit2;
	private float maxLimit2;
	private JointLimits limits;
	private JointLimits limits2;

	void Start() {
		if (door != null) {
			limits =  door.GetComponent<HingeJoint> ().limits;
			minLimit = limits.min;
			maxLimit = limits.max;
			limits.min = 0;
			limits.max = 0;
			door.GetComponent<HingeJoint> ().limits = limits;
			door.gameObject.GetComponent<HingeJoint> ().enablePreprocessing = true;

		}
		if (door2 != null) {
			limits2 =  door2.GetComponent<HingeJoint> ().limits;
			minLimit2 = limits2.min;
			maxLimit2 = limits2.max;
			limits2.min = 0;
			limits2.max = 0;
			door2.GetComponent<HingeJoint> ().limits = limits2;
			door2.gameObject.GetComponent<HingeJoint> ().enablePreprocessing = true;
		}

	}

	void Update() {
	}
			
	void OnTriggerEnter (Collider collider) {	
		Debug.Log (collider);
		if(collider.gameObject == key) {
			audio = this.gameObject.GetComponentInParent<AudioSource> ();
			if (locked) {
				audio.Play();
				if (hasLock) {
					this.GetComponentInParent<Animation> ().Play ("lock_open");
					Destroy (transform.parent.gameObject, 1.0f);
				}

				if (drawer != null) {
					OpenDrawer ();
				}
				if (door != null) {
					OpenDoor ();
				}
				locked = false;
			}

		}
	}

	void OpenDrawer() {
		joint = drawer.gameObject.GetComponentInParent<ConfigurableJoint> ();
		if (motionAxis == 1) {
			joint.xMotion = ConfigurableJointMotion.Limited;
		} else if (motionAxis == 2) {
			joint.yMotion = ConfigurableJointMotion.Limited;
		} else if (motionAxis == 3) {
			joint.zMotion = ConfigurableJointMotion.Limited;
		}
		if (!hasLock) {
			drawer.gameObject.GetComponentInParent<Rigidbody>().velocity = new Vector3(1,1,1);
		}
	}

	void OpenDoor () {
		limits =  door.GetComponent<HingeJoint> ().limits;
		limits.min = minLimit;
		limits.max = maxLimit;
		door.GetComponent<HingeJoint> ().limits = limits;
		door.gameObject.GetComponent<HingeJoint> ().enablePreprocessing = false;
		if (!hasLock) {
			door.GetComponent<HingeJoint> ().useMotor = true;
		}
		if (door2 != null) {
			limits2 =  door.GetComponent<HingeJoint> ().limits;
			limits2.min = minLimit2;
			limits2.max = maxLimit2;
			door2.GetComponent<HingeJoint> ().limits = limits2;
			door2.gameObject.GetComponent<HingeJoint> ().enablePreprocessing = false;
			if (!hasLock) {
				door2.GetComponent<HingeJoint> ().useMotor = true;
			}
		}
	}
}