using UnityEngine;
using System.Collections;
//LÖSCHENS
public class OtherDrawerEnter : MonoBehaviour {

	public GameObject otherDrawer;
	public GameObject drawerHandler;


	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject == drawerHandler) {
			otherDrawer.GetComponent<TriggerDrawer> ().open = true;
		}
	}
}
