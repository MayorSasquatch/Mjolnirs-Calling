using UnityEngine;
using System.Collections;

public class MenuFunc : MonoBehaviour {
	public GameObject MainMenuItems;
	public GameObject CreditsItems;

	// Use this for initialization
	void Start () {
	
	}
	public void PlayButtonFunction()
	{
		Application.LoadLevel("Game");
	}

	public void CreditButtonFunction()
	{
		MainMenuItems.SetActive(false);
		CreditsItems.SetActive(true);


	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.LoadLevel("MenuScene");
	}
}
