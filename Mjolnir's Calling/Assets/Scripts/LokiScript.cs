using UnityEngine;
using System.Collections;

public class LokiScript : MonoBehaviour {
	bool on = false;
	float time = 0f;
	float ttime = 0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		ttime  += Time.deltaTime;
		//print(ttime + "  " + time);
		if(HammerMove.loki == true && !on){
			spin();
			on = true;
			time = 0;
			//GameObject.Find("Cylinder").GetComponent<ObjectSpawn>().spawnGroup();
			//GameObject.Find("Cylinder").transform.Rotate(new Vector3(180,0,0));
		}
		if(time >= 3f && HammerMove.loki == true){
			on = false;
			this.rigidbody.angularVelocity = new Vector3(0,0,0);
			this.transform.eulerAngles = new Vector3 (0f,180f,0f);
			HammerMove.loki = false;
		}



		if(ttime > 5f && ttime < 6f){HammerMove.loki = true;}
	}

	void spin(){
		this.rigidbody.AddRelativeTorque(new Vector3(0,0, 105f));
	}
}
