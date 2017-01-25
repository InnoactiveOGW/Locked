using UnityEngine;
using System.Collections;

public class MysteryLockOpener : MonoBehaviour {
	public int keyCount;
	public GameObject pointLight;
	//public GameObject winLight;
    public Material whiteSkybox;

	public void OpenDoor () {
		pointLight.SetActive (true);
		//winLight.SetActive (true);
		this.GetComponentInParent<Rigidbody> ().isKinematic = false;
		this.GetComponentInParent<HingeJoint> ().useMotor = true;
        RenderSettings.skybox = whiteSkybox;
    }
}
