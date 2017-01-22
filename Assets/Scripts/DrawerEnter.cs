using UnityEngine;
using System.Collections;

public class DrawerEnter : MonoBehaviour {

	public GameObject otherDrawer;
	public GameObject drawerHandler;
	public bool open;
	public bool isLocker;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject == drawerHandler) {
			if (isLocker) {
				otherDrawer.GetComponent<Rigidbody> ().isKinematic = true;
			} else {
				otherDrawer.GetComponent<TriggerDrawer> ().open = open;
			}
		}
	}
}
