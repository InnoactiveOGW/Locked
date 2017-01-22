using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	public bool end = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (end) {
			EndGameMethod ();
		}
	}

	void EndGameMethod () {
		Application.Quit();
	}
}
