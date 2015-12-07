using UnityEngine;
using System.Collections;

public class StageSelect : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ControlInputWrapper.GetButtonDown(ControlInputWrapper.Buttons.A))
        {
            Application.LoadLevel("JapaneseStage");
        }

        if (ControlInputWrapper.GetButtonDown(ControlInputWrapper.Buttons.X))
        {
            Application.LoadLevel("IceStage");
        }

        if (ControlInputWrapper.GetButtonDown(ControlInputWrapper.Buttons.Y))
        {
            Application.LoadLevel("HellStage");
        }

        if (ControlInputWrapper.GetButtonDown(ControlInputWrapper.Buttons.B))
        {
            Application.LoadLevel("SwampStage");
        }
    }
}
