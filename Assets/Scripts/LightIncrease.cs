using UnityEngine;
using System.Collections;

public class LightIncrease : MonoBehaviour {

	float smoothValue = 1.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<Light> ().intensity <= 3) {
			this.GetComponent<Light> ().intensity += smoothValue * Time.deltaTime;
		}
	}
}
