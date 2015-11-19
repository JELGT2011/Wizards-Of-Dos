using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;


public class CreditsScript : MonoBehaviour {

	float speed = 100;
	int screenHeight;
	Text TextGUI;
	float textHeight;
	// Use this for initialization
	
	void Start () {
		screenHeight = Screen.height;
		print (screenHeight);
		TextGUI = GetComponent<Text>();
		/*
		StringBuilder credits = new StringBuilder();
		credits.Append("Credits\n");
		credits.Append("Level Design:\nNate Ziran Chen\nLanssie Ma\n");
		TextGUI.text = credits.ToString();
		*/
	}
	
	// Update is called once per frame
	void Update () {
		// Scroll credits up
		transform.Translate(Vector3.up * Time.deltaTime * speed);
		// TODO: Needs to be updated to be more consistent
		if(transform.position.y > screenHeight){
			LoadMenuScreen();
		}
	}
	
	public void LoadMenuScreen(){
		Application.LoadLevel("MenuScreen");
	}
}
