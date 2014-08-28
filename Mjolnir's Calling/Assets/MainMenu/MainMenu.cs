using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private delegate void GUIMethod();
	
	private GUIMethod currentGUIMethod; 
	
	public GameObject mainButtons;
	public GameObject playEmpty;
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
		mainButtons.SetActive(false);
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
	
	void Update()
	{
		if(pressed_Button == "Play")
		{
			this.currentGUIMethod = PlayButton;
		}else if(pressed_Button == "Credits")
		{
			this.currentGUIMethod = CreditsButton;
		}
		
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			pressed_Button = "Main";
			this.currentGUIMethod = MainButton;
		}
		this.currentGUIMethod();
	}
}
