using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FillAmt : MonoBehaviour {
	public Image img;
	float playerHealth;
	float t_num;
	// Use this for initialization
	void Start () {
		playerHealth = HammerMove.player_hp; // = health_player;
		t_num = playerHealth / 100;
	}
	
	// Update is called once per frame
	void Update () {
		//if(img.fillAmount != 0)
		//{
		//img.fillAmount -= .005f;
			//print("sub fill");
		//}
		playerHealth = HammerMove.player_hp;
		if(Input.GetKey(KeyCode.UpArrow))
		{
		   playerHealth += 1;
			print ("up");
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
		   playerHealth -= 1;
			print ("down");
		}

		if(playerHealth > 100)
		   playerHealth = 100;
		if(playerHealth < 1)
		   playerHealth = 1;

		t_num = playerHealth / 100;

		img.fillAmount = t_num;
	}

}
