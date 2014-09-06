using UnityEngine;
using System.Collections;

public class ObjectDestroy : MonoBehaviour {

	float degUntilDestroy;
	Transform start;
	// Use this for initialization
	void Start () {
		degUntilDestroy = 330;
		start = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

		if(this.transform.parent != null)degUntilDestroy -= CylinderRotate.curSpeed;

		if(degUntilDestroy <= 0) {
			degUntilDestroy = 330;
			this.transform.parent = null;
			this.transform.position = start.position;
			this.transform.rotation = start.rotation;
		} 
	}
}
