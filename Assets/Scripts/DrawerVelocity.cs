using UnityEngine;
using System.Collections;

public class DrawerVelocity : MonoBehaviour {

	private Vector3 myVelocity;
	private Vector3 otherVelocity;
	public GameObject otherDrawer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		otherVelocity = otherDrawer.GetComponent<Rigidbody> ().velocity;
		myVelocity = GetComponent<Rigidbody> ().velocity;

		//otherVelocity.z = myVelocity.z;

		//otherDrawer.GetComponent<Rigidbody> ().AddForce (0,0,GetComponent<Rigidbody> ().velocity.z * 5);
		//Debug.Log (GetComponent<Rigidbody> ().velocity);
		if (myVelocity.z > 0 || myVelocity.z < 0) {
			otherDrawer.GetComponent<ConfigurableJoint> ().yMotion = ConfigurableJointMotion.Limited;
			otherVelocity.z = myVelocity.z * -10f;
			//otherDrawer.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, myVelocity.z * -10f);

		} else {
			otherDrawer.GetComponent<ConfigurableJoint> ().yMotion = ConfigurableJointMotion.Locked;
		}

		/*if (myVelocity.z > 0) {
			otherDrawer.GetComponent<ConfigurableJoint> ().yMotion = ConfigurableJointMotion.Limited;
			otherDrawer.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, -10f);
		}
		else if(myVelocity.z < 0) {
			otherDrawer.GetComponent<ConfigurableJoint> ().yMotion = ConfigurableJointMotion.Limited;
			otherDrawer.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 10f);

		}*/
	}
}
