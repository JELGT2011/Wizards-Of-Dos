﻿using UnityEngine;
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

        if (_characterController.PlayerAssign == "J1")
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
        else if (_characterController.PlayerAssign == "J2")
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

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rdc.triggerRagdoll();
            _animator.SetTrigger("DeathTrigger");
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
            rdc.triggerRagdoll();
            _animator.SetTrigger("DeathTrigger");
        }
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

	public void AddBuff(string name, float duration){
		buffList.Add (name, duration);
	}

	public void RemoveBuff(string name){
		if (buffList.ContainsKey (name))
			buffList.Remove (name);
	}

	public bool HasBuff(string name){
		if (buffList.ContainsKey (name) && buffList [name] <= 0)
			buffList.Remove (name);
		return buffList.ContainsKey(name);
	}

}
