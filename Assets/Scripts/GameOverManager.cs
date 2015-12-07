using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameOverManager : MonoBehaviour
{
    Text gameOverText;
    public float restartDelay = 8f;
    bool gameOver = false;

    Animator anim;
    float restartTimer;

    void Start()
    {
        anim = GetComponent<Animator>();

        gameOverText = GetComponentInChildren<Text>();
		
    }



    public void PlayerDeath()
    {
		anim.SetTrigger("GameOver");
		Invoke ("ReloadMenu", 5f);

    }

	public void ReloadMenu(){
		Application.LoadLevel("MenuScreen");
	}
}
