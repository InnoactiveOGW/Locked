using UnityEngine;
using System.Collections;

public class MirrorOpen : MonoBehaviour {

	public GameObject LeftHand;
	public GameObject RightHand;
	public GameObject Plane;
	private GameObject[] Torches;
	private Light[] Fire;
	private bool locked = true;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		Torches = GameObject.FindGameObjectsWithTag ("Torch");


	}
	
	// Update is called once per frame
	void Update () {
		if (LeftHand.GetComponent<Hand> ().handHovering && RightHand.GetComponent<Hand> ().handHovering) {
			if (locked) {
				OpenMirror ();
				locked = false;
			}
		}
	}

	void OpenMirror () {
		audio = this.gameObject.GetComponentInParent<AudioSource> ();
		foreach (GameObject i in Torches) {
			i.SetActive (false);
		}
		StartCoroutine(JumpScare(audio));

	}

	IEnumerator JumpScare(AudioSource audio) {
		yield return new WaitForSeconds (0.5f);
		audio.Play();
		Plane.SetActive (true);
		foreach (GameObject i in Torches) {
			i.SetActive (true);
		}
		StartCoroutine(OpenChamber());
	}

	IEnumerator OpenChamber() {
		yield return new WaitForSeconds (1f);
		Destroy (Plane.gameObject);
		Destroy (this.transform.parent.gameObject);

	}
}
