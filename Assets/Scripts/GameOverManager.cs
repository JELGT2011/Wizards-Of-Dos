using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameOverManager : MonoBehaviour
{
	public CharacterStats Player1Health;
	public CharacterStats Player2Health;
	int player1health = 100;
	int player2health = 100;
	Text gameOverText;
	public float restartDelay = 8f;
	bool gameOver = false;
	
	Animator anim;
	float restartTimer;
	
	void Awake()
	{
		anim = GetComponent<Animator>();
		/*Player1Health = GameObject.FindGameObjectWithTag("Player1").GetComponent<CharacterStats>();
		Player2Health = GameObject.FindGameObjectWithTag("Player2").GetComponent<CharacterStats>();*/
		gameOverText = GetComponentInChildren<Text>();
	}
	
	
	void Update()
	{
		if(Player1Health == null){
			Player1Health = GameObject.FindGameObjectWithTag("Player1Char").GetComponent<CharacterStats>();
		}
		if(Player2Health == null){
			Player2Health = GameObject.FindGameObjectWithTag("Player2Char").GetComponent<CharacterStats>();
		}
		player1health = Player1Health.GetHealth();
		player2health = Player2Health.GetHealth();	
		if(player1health <= 0 || player2health <= 0){
			if(player1health <= 0){
				gameOverText.text = "Player 2 Wins!";
			}
			if(player2health <= 0){
				gameOverText.text = "Player 1 Wins!";
			}
			anim.SetTrigger("GameOver");
			restartTimer +=  Time.deltaTime;
			if(restartTimer >= restartDelay){
				Application.LoadLevel("MenuScreen");
			}
		}
		
	}
}
