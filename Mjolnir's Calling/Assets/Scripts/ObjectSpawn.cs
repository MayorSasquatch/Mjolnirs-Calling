using UnityEngine;
using System.Collections;

public class ObjectSpawn : MonoBehaviour {

	public GameObject[] objects;

	float[] xCoord = {30, 10, -10, -30};
	int numObj = 3;
	bool powerUpSpawned;

	float treeOdds = 100;
	float pUpOdds = 0;

	// Use this for initialization
	void Start () {
		spawnGroup();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void spawnGroup () {
		int[] occupied = {-1, -1, -1};
		powerUpSpawned = false;

		for(int i = 0; i<numObj; i++){
			int column = (int)Random.Range(0, 3);
			int row = (int)Random.Range(0, 2);

			while(column == occupied[0] || column == occupied[1])
				column = (int)Random.Range(0, 3);

			occupied[i] = column;

			int objType = Random.Range(0, 100);

			/*
			if(objType < pUpOdds && !powerUpSpawned){
				
			}
			else if(objType < treeOdds){
				
			}
			*/
			spawnObject(0, column, row);
		}
	}

	void spawnObject (int objType, int column, int row) {

		GameObject obj = (GameObject)Instantiate(objects[objType], new Vector3(xCoord[column],-60,0), new Quaternion(0,180,0,0));
		obj.transform.parent = this.transform;
	}
}
