using UnityEngine;
using System.Collections;

public class ObjectSpawn : MonoBehaviour {

	public GameObject[] objectTypes;

	//Coordinates and angles for objects to spawn at on the cylinder
	float[] xCoord = {30, 10, -10, -30};
	float[] yCoord = {-60, 60*Mathf.Sin(300*Mathf.Deg2Rad), 60*Mathf.Sin(330*Mathf.Deg2Rad)};
	float[] zCoord = {0, 60*Mathf.Cos(300*Mathf.Deg2Rad), 60*Mathf.Cos(330*Mathf.Deg2Rad)};
	float[] angle = {180, 150, 120};

	int numObj = 3;	//Number of objects to spawn per group/wave
	int waveCount; //Number of waves survived
	bool powerUpSpawned; //Boolean to track whether a power up has been spawned this wave

	float degUntilNextGroup; //How much rotation in degrees until the next group is spawned
	float degUntilNextWave; //How much rotation in degrees until the wave counter is incremented

	// Use this for initialization
	void Start () {
		waveCount = 0;
		degUntilNextGroup = 0;
		degUntilNextWave = 330;
	}
	
	// Update is called once per frame
	void Update () {
	
		float speed = CylinderRotate.curSpeed; //Current rotation speed of the cylinder in degrees
		degUntilNextGroup -= speed;
		degUntilNextWave -= speed;

		//Determine if it is time to spawn the next group
		if(degUntilNextGroup <= 0){
			spawnGroup();
			degUntilNextGroup += 180;
		}

		//Determine if it is time to increment the wave counter
		if(degUntilNextWave <= 0){
			waveCount++;
			degUntilNextWave += 180;
		}
		Debug.Log(waveCount);

	}

	//Function that spawns object groups (waves)
	void spawnGroup () {
		int[] occupied = {0, 0, 0, 0}; //Array to store which columns are already occupied
		powerUpSpawned = false;	//Set power up spawned boolean to false for start of this wave



		//Spawns numObj number of objects
		for(int i = 0; i<numObj; i++){
			int column = (int)Random.Range(0, 4); //Pick a random column
			int row = (int)Random.Range(0, 3); //Pick a random row

			while(occupied[column] == 1)
				column = (int)Random.Range(0, 4); //If the column is already occupied, pick again

			occupied[column] = 1; //Set chosen column to occupied

			//Spawn the chosen object and set its parent to the cylinder
			GameObject objs = (GameObject)Instantiate(objectTypes[determineObject()], new Vector3(xCoord[column],yCoord[row],zCoord[row]), Quaternion.Euler(angle[row],0,0));
			objs.transform.parent = this.transform;

		}
	}

	//Probability array locations: {tree, rock, crystal spire, Health power up, Lightning power up, Loki power up}
	float[] objProbs = {80, 0, 0, 10, 5, 5}; //Object spawn probabilities
	float[] cumProbs = new float[6]; //Cumulative object spawn probabilities

	//Function to adjust spawn probabilities depending on wave number
	void waveAdjust (int waveNum) {

		if(waveNum <= 20) updateProbs(-1, 1, 0, 0, 0, 0);	// 60, 20, 0, 10, 5, 5

		else if(waveNum <= 40) updateProbs(-1.5, 0.5, 1, 0, 0, 0);	// 30, 30, 20, 10, 5, 5

		else if (waveNum <= 60) updateProbs(-1, 0.75, 0.25, 0, 0, 0);	// 10, 45, 25, 10, 5, 5

		else if (waveNum <= 95) updateProbs(0, -1, 1, 10, 5, 5);	// 10, 10, 60, 10, 5, 5

		else if (waveNum <= 100) updateProbs(0, 0, 0, -1, -0.5, 1.5); // 10, 10, 60, 5, 2.5, 12.5
	}

	//Function to update the object spawn probabilities
	void updateProbs (float tree, float rock, float crystal, float pUHealth, float pULight, float pULoki) {

		objProbs[0] += tree;
		objProbs[1] += rock;
		objProbs[2] += crystal;
		objProbs[3] += pUHealth;
		objProbs[4] += pULight;
		objProbs[5] += pULoki;

		//Update cumulative object spawn probabilities
		for(int i=0; i<6; i++){
			cumProbs[i] = objProbs[i];

			for(int j=i-1; j>=0; j--)
				cumProbs[i] += objProbs[j];
		}
	}

	//Function to determine what object to spawn
	int determineObject () {

		//If a power up has not been spawned, include its cumulative prob in the range. If one has been spawned, exclude it from the range
		float prob;
		if(!powerUpSpawned) prob = Random.Range(0, 100);
		else prob = Random.Range(0, 80);

		for(int i=0; i<6; i++){
			if(prob <= cumProbs[i]) return i;
		}

	}

}
