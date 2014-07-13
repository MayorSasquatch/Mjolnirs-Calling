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

		degUntilDestroy -= CylinderRotate.curSpeed;

		if(degUntilDestroy <= 0) Destroy(this.gameObject);
	}
}
