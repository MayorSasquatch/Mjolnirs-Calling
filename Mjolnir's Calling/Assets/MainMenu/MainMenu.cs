using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private delegate void GUIMethod();
	
	private GUIMethod currentGUIMethod; 
	
	public GameObject mainButtons;
	public GameObject playEmpty;

	public GameObject playRock;
	public GameObject creditRock;

	public GameObject playText;
	public GameObject creditText;

	//public GameObject optionsEmpty;
	public GameObject creditsEmpty;
	
	public static string pressed_Button;
	
	
	void Start () 
	{ 
		// start with the main menu GUI
		this.currentGUIMethod = MainButton; 
	} 
	
	private void MainButton() 
	{ 
		//playEmpty.SetActive(false);
		//optionsEmpty.SetActive(false);
		creditsEmpty.SetActive(false);
		mainButtons.SetActive(true);
	} 
	private void PlayButton()
	{
		print ("Play");

		Application.LoadLevel("Game");
		//mainButtons.SetActive(false);
		//playEmpty.SetActive(true);
	}
	/*
	private void OptionsButton()
	{
		print ("Options");
		mainButtons.SetActive(false);
		optionsEmpty.SetActive(true);
	}    
	*/
	private void CreditsButton()
	{
		print ("Credits");
		mainButtons.SetActive(false);
		creditsEmpty.SetActive(true);
	}


	void StartPlayFunction()
	{
		this.currentGUIMethod = PlayButton;
	}
	void StartCreditFunction()
	{
		this.currentGUIMethod = CreditsButton;
	}
	void Update()
	{
		if(pressed_Button == "Play")
		{

			if(playText.renderer.material.color.a > 0)
				playText.renderer.material.color -= new Color(0,0,0,.075f);
			playRock.GetComponent<Animator>().SetTrigger("Break");
	
			Invoke("StartPlayFunction", .35f);
			//this.currentGUIMethod = PlayButton;
		}
		else if(pressed_Button == "Credits")
		{

			if(creditText.renderer.material.color.a > 0)
				creditText.renderer.material.color -= new Color(0,0,0,.075f);
			creditRock.GetComponent<Animator>().SetTrigger("Break");

			Invoke("StartCreditFunction", .35f);
			//this.currentGUIMethod = CreditsButton;
		}
		
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			pressed_Button = "Main";
			//this.currentGUIMethod = MainButton;
			Application.LoadLevel("MainMenu");
		}
		this.currentGUIMethod();
	}
}
