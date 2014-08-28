using UnityEngine;
using System.Collections;

public class ButtonState : MonoBehaviour {
	void OnMouseDown()
	{
		print (this.gameObject.name);
		MainMenu.pressed_Button = this.gameObject.name;
	
	}

}
