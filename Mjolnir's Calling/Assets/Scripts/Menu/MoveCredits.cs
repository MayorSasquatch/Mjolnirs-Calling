using UnityEngine;
using System.Collections;

public class MoveCredits : MonoBehaviour {
	public float creditsVelocity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0, creditsVelocity * Time.deltaTime , 0);
	}
}
