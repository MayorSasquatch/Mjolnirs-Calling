using UnityEngine;
using System.Collections;

public class CylinderRotate : MonoBehaviour {

	public float startSpeed;
	public float speedCap;
	public float speedIncreaseRate;
	public static float curSpeed;
	float rotation;

	void Start () {
		curSpeed = startSpeed/10;
		speedIncreaseRate = speedIncreaseRate/10000;
		speedCap = speedCap/10;
	}

	// Update is called once per frame
	void Update () {

		if(curSpeed < speedCap) curSpeed += speedIncreaseRate; // Increase speed if speed cap has not been reached

		transform.Rotate(curSpeed,0,0,Space.World);	// Rotate the cylinder
		//rigidbody.AddTorque(100,0,0);
	}
}
