using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] _weapons;
    public GameObject[] Weapons
    {
        get { return _weapons; }
        set { _weapons = value; }
    }

    [SerializeField]
    protected ParticleSystem[] _particleEffects;
    public ParticleSystem[] ParticleEffects
    {
        get { return _particleEffects; }
        set { _particleEffects = value; }
    }

    void Start()
    {
        if (_weapons == null)
        {
            Debug.Log("Weapon cannot be null");
        }

        if (_particleEffects == null)
        {
            Debug.LogWarning("There are no particle effects on this weapon manager.");
        }
    }

    public void TriggerParticlesEffects()
    {
        foreach (ParticleSystem _particleSystem in _particleEffects)
        {
            if (_particleSystem != null)
            {
                _particleSystem.Play();
            }
        }
    }
}
