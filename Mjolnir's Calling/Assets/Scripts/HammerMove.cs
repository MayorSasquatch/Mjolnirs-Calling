using UnityEngine;
using System.Collections;

public class HammerMove : MonoBehaviour {

	float orientation = 0;
	public float boundaryWidth;
	public float speed;

	// Update is called once per frame
	void Update () {
	
		orientation = Input.gyro.attitude.eulerAngles.y;

		if(Input.GetKey(KeyCode.A) && this.transform.position.x < boundaryWidth){
			Debug.Log("Left");
			this.rigidbody.AddForce(speed,0,0);
		}
		else if(Input.GetKey(KeyCode.D) && this.transform.position.x > -boundaryWidth){ 
			Debug.Log("Right");
			this.rigidbody.AddForce(-speed,0,0);
		}
		else{ 
			Debug.Log("Center");
			//this.rigidbody.velocity = new Vector3(0,0,0);
		}

	}
}
