using UnityEngine;
using System.Collections;

public class lightning : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		print (HammerMove.lightning);
		if(HammerMove.lightning > 0){
			HammerMove.lightning--;
		//print("blah");
		GameObject[] temp= GameObject.FindGameObjectsWithTag("Object");
		foreach(GameObject blah in temp){
			if(blah.transform.parent != null){
				blah.transform.parent = null;
				blah.transform.position = new Vector3 (0, -300, 0);
			}
		}
		}
	}
}
