using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EkkoController : MonoBehaviour
{

    [SerializeField]
    protected Animator _animator;
    public Animator Animator
    {
        get { return _animator; }
        protected set { _animator = value; }
    }

    [SerializeField]
    protected Text _controllerGUI;
    public Text ControllerGUI
    {
        get { return _controllerGUI; }
        protected set { _controllerGUI = value; }
    }

    [SerializeField]
    protected GameObject _weapon;
    public GameObject Weapon
    {
        get { return _weapon; }
        set { _weapon = value; }
    }

    void Start()
    {
        if (!_animator)
        {
            _animator = GetComponentInChildren<Animator>();
        }


    }

    void Update()
    {

    }

    void FixedUpdate()
    {

        float X = ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.LeftStickX);
        float Y = ControlInputWrapper.GetAxis(ControlInputWrapper.Axis.LeftStickY);
        //float X = 0.5f;
        //float Y = 0.5f;
        float Speed = Mathf.Min(Mathf.Sqrt((X * X) + (Y * Y)), 1f);
        float Angle = Mathf.Rad2Deg * Mathf.Atan(X / Y);

        if (float.IsNaN(Angle))
        {
            Angle = 0f;
        }

        if (Y < 0f)
        {
            Angle += 180f;

        }
        

        _controllerGUI.text = "Y: " + X + "\n"
                    + "X: " + Y + "\n"
                    + "Speed: " + Speed + "\n"
                    + "Angle: " + Angle
                    ;

        _animator.SetFloat("speed", Speed);

        transform.rotation = Quaternion.Euler(0f, Angle, 0f);

        if (ControlInputWrapper.GetButtonDown(ControlInputWrapper.Buttons.A))
        {
            _animator.SetTrigger("jump");
        }
        else if (ControlInputWrapper.GetButtonDown(ControlInputWrapper.Buttons.X))
        {
            _animator.SetTrigger("left_attack");
        }
        else if (ControlInputWrapper.GetButtonDown(ControlInputWrapper.Buttons.B))
        {
            _animator.SetTrigger("right_attack");
        }
        else if (ControlInputWrapper.GetButtonDown(ControlInputWrapper.Buttons.Y))
        {
            _animator.SetTrigger("center_combo");
        }

    }
}
