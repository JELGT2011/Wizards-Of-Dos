using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharacterStats : MonoBehaviour
{

    [SerializeField]
    protected int startingHealth = 100;

    protected int _currentHealth;
    public int CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    protected StandardCharacterController _characterController;

    [SerializeField]
    protected Slider _healthSlider;

    int attack1Damage = 20;
    int attack2Damage = 15;
    int attack3Damage = 30;

    protected Animator _animator;

    Dictionary<string, int> attackDamage = new Dictionary<string, int>();

    RagdollController rdc;

    protected Dictionary<string, float> buffList; //buff name, durations

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        attackDamage.Add("Attack1", attack1Damage);
        attackDamage.Add("Attack2", attack2Damage);
        attackDamage.Add("Attack3", attack3Damage);
        rdc = GetComponent<RagdollController>();
        _currentHealth = startingHealth;

        _characterController = GetComponentInChildren<StandardCharacterController>();

        GameObject HUD = GameObject.FindGameObjectWithTag("HUD");

        if (_characterController._playerAssign == "J1" || _characterController._playerAssign == "K1")
        {
            Slider[] _sliders = HUD.GetComponentsInChildren<Slider>();
            foreach (Slider _slider in _sliders)
            {
                if (_slider.tag == "Player1")
                {
                    _healthSlider = _slider;
                }
            }
        }
        else if (_characterController._playerAssign == "J2" || _characterController._playerAssign == "K2")
        {
            Slider[] _sliders = HUD.GetComponentsInChildren<Slider>();
            foreach (Slider _slider in _sliders)
            {
                if (_slider.tag == "Player2")
                {
                    _healthSlider = _slider;
                }
            }
        }

        buffList = new Dictionary<string, float>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //update buffs
        List<string> buffNames = new List<string>(buffList.Keys);
        foreach (string buff in buffNames)
        {
            buffList[buff] = buffList[buff] - Time.deltaTime;
            if (buffList[buff] <= 0)
            {
                if (buff.Equals("SwampDamage") && !HasBuff("BigTreeGrace"))
                {
                    TakeDamage(10);
                    RemoveBuff("SwampDamage");
                    AddBuff("SwampDamage", 2f);
                }
                else if (buff.Equals("BigTreeGrace"))
                {
                    RemoveBuff("BigTreeGrace");
                    foreach (Transform t in gameObject.transform)
                    {
                        if (t.tag == "SwampBuffOnPlayer")
                        {
                            Destroy(t.gameObject);
                        }
                    }
                }
            }
        }

		if (gameObject.transform.position.y < -5) {
			TakeDamage(100);
		}
    }

    void OnGUI()
    {
        _healthSlider.value = _currentHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        //healthSlider.value = currentHealth;
        if (_currentHealth <= 0)
        {
            _animator.SetTrigger("DeathTrigger");
			rdc.triggerRagdoll();
            GameObject.FindGameObjectWithTag("HUD").GetComponentInChildren<GameOverManager>().PlayerDeath();
        }
    }

    public void AddHealth(int h)
    {
        //Debug.Log("old health");
        //Debug.Log (_currentHealth);
        //healthSlider.value = currentHealth;
        if (_currentHealth + h > startingHealth)
        {
            _currentHealth = 100;
        }
        else
        {
            _currentHealth += h;
        }
        //Debug.Log("new health");
        //Debug.Log (_currentHealth);
    }

    //Return the damage from an attack given its name
    public int GetAttackDamage(string attack)
    {
        int damage;
        if (attackDamage.TryGetValue(attack, out damage))
        {
            return damage;
        }
        else
        {
            return 0;
        }
    }

    public void AddBuff(string name, float duration)
    {
        buffList.Add(name, duration);
    }

    public void RemoveBuff(string name)
    {
        if (buffList.ContainsKey(name))
            buffList.Remove(name);
    }

    public bool HasBuff(string name)
    {
        if (buffList.ContainsKey(name) && buffList[name] <= 0)
            buffList.Remove(name);
        return buffList.ContainsKey(name);
    }

    public int GetHealth()
    {
        return _currentHealth;
    }

}
