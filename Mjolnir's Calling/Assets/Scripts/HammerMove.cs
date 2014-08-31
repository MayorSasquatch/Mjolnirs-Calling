using UnityEngine;
using System.Collections;

public class HammerMove : MonoBehaviour {
	float xatstart = 0;
	float yatstart = 0;
	public static int lightning = 0;

	
	Vector3 Move;
	Vector3 dir;
	Vector3 tester;



	float orientation = 0;
	public float boundaryWidth;
	public float speed;
	public static bool loki = false;

	public static float player_hp;
	void Start()
	{
		player_hp = 100;

		xatstart = Input.acceleration.x;
		yatstart = Input.acceleration.y;
	}
	void accelerometorControls()
	{


		tester = Input.acceleration;
		
		//Debug.Log(tester);
		
		
		Vector3 dir = Vector3.zero;
		
		// we assume that the device is held parallel to the ground
		// and the Home button is in the right hand
		
		// remap the device acceleration axis to game coordinates:
		//  1) XY plane of the device is mapped onto XZ plane
		//  2) rotated 90 degrees around Y axis
		dir.y = (-Input.acceleration.y-yatstart);
		dir.x = (Input.acceleration.x);
		
		// clamp acceleration vector to the unit sphere
		if (dir.sqrMagnitude > 1)
			dir.Normalize();
		
		// Make it move 10 meters per second instead of 10 meters per frame...
		//dir *= Time.deltaTime;
		
		// Move object
		Move = new Vector3 (-speed * dir.x,0, 0);
		
		//transform.rigidbody.velocity = Move;
		transform.Translate(Move.x, Move.y, Move.z);
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp(pos.x, -(boundaryWidth/2) , (boundaryWidth/2) );
		transform.position = pos;
		dir = Vector3.zero;

	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Object")
		{
			if(col.transform.name == "object6(Clone)"){
				HammerMove.loki = true;
			}
			else if(col.transform.name == "object5(Clone)"){
				lightning += lightning <3 ?  1 : 0;

			}
			else if(col.transform.name == "object4(Clone)"){
				player_hp += 30;
				if(player_hp > 100)player_hp = 100;
			}
			else{
				print ("HIT OBJECT");
				player_hp -= 30;
			}
		}


	}
	// Update is called once per frame
	void Update () {

		orientation = Input.gyro.attitude.eulerAngles.y;

		if(Input.GetKey(KeyCode.A) && this.transform.position.x < boundaryWidth){
			//Debug.Log("Left");
			this.rigidbody.AddForce(loki? -speed : speed,0,0);
		}
		else if(Input.GetKey(KeyCode.D) && this.transform.position.x > -boundaryWidth){ 
			//Debug.Log("Right");
			this.rigidbody.AddForce(loki ? speed : -speed,0,0);
		}
		else{ 
			//Debug.Log("Center");
			//this.rigidbody.velocity = new Vector3(0,0,0);
		}
		/*
		if(player_hp == 0)
			UnityEditor.EditorApplication.isPlaying = false;*/
		//accelerometorControls();
	}
}
