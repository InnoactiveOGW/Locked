using UnityEngine;
using System.Collections;
//LÖSCHEN?
public class Locker : MonoBehaviour {

	public GameObject otherDrawer;
	public GameObject drawerHandler;


	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject == drawerHandler) {
			otherDrawer.GetComponent<Rigidbody>().isKinematic = true;
		}
	}
}
