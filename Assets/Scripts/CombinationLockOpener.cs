using UnityEngine;
using System.Collections;

public class CombinationLockOpener : MonoBehaviour {

	public string solution1;
	public string solution2;
	public string solution3;
	public string solution4;
	public GameObject result1;
	public GameObject result2;
	public GameObject result3;
	public GameObject result4;

	private AudioSource audio;
	private bool locked = true;

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

	// Use this for initialization
	void Start () {
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
	
	// Update is called once per frame
	void Update () {
		if (result1.GetComponent<TextMesh> ().text == solution1 &&
		    result2.GetComponent<TextMesh> ().text == solution2 &&
		    result3.GetComponent<TextMesh> ().text == solution3) {
			if (result4 != null) {
				if (result4.GetComponent<TextMesh> ().text == solution4) {
					OpenCombinationLock ();
				}
			} else {
				OpenCombinationLock ();
			}

		}
	}

	void OpenCombinationLock () {
		audio = this.gameObject.GetComponentInParent<AudioSource> ();
		if (locked) {
			audio.Play();
			this.GetComponentInParent<Animation> ().Play("lock_open");
			Destroy(this.gameObject, 1.0f);

			if (drawer != null) {
				OpenDrawer ();
			}
			if (door != null) {
				OpenDoor ();
			}
			locked = false;
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
	}

	void OpenDoor () {
		limits =  door.GetComponent<HingeJoint> ().limits;
		limits.min = minLimit;
		limits.max = maxLimit;
		door.GetComponent<HingeJoint> ().limits = limits;
		door.gameObject.GetComponent<HingeJoint> ().enablePreprocessing = false;
		if (door2 != null) {
			limits2 =  door.GetComponent<HingeJoint> ().limits;
			limits2.min = minLimit2;
			limits2.max = maxLimit2;
			door2.GetComponent<HingeJoint> ().limits = limits2;
			door2.gameObject.GetComponent<HingeJoint> ().enablePreprocessing = false;
		}
	}
}
