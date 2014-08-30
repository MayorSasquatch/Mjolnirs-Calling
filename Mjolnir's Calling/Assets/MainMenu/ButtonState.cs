using UnityEngine;
using System.Collections;

public class ButtonState : MonoBehaviour {
	void OnMouseUp()
	{
		print (this.gameObject.name);
		MainMenu.pressed_Button = this.gameObject.name;
	
	}

}
