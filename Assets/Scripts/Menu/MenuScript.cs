using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject eventSystem = GameObject.Find("EventSystem");
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    // Update is called once per frame
    void Update()
    {
        if (ControlInputWrapper.GetButtonDown(ControlInputWrapper.Buttons.A))
        {
            Application.LoadLevel("CharacterSelect");
        }
        
        if (ControlInputWrapper.GetButtonDown(ControlInputWrapper.Buttons.B))
        {
            Application.LoadLevel("Credits");
        }
    }

    public void LoadCharacterSelect()
    {
        Application.LoadLevel("CharacterSelect");
    }

    public void LoadCredits()
    {
        Application.LoadLevel("Credits");
    }
}
