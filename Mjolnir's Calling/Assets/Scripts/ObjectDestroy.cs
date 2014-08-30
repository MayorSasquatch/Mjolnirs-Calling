using UnityEngine;
using System.Collections;

public class ObjectDestroy : MonoBehaviour {

	float degUntilDestroy;

	// Use this for initialization
	void Start () {
		degUntilDestroy = 330;
	}
	
	// Update is called once per frame
	void Update () {

		if(this.transform.parent != null)degUntilDestroy -= CylinderRotate.curSpeed;

		if(degUntilDestroy <= 0) {
			degUntilDestroy = 330;
			this.transform.parent = null;
			this.transform.position = new Vector3(0,-300, 0);
		} 
	}
}
