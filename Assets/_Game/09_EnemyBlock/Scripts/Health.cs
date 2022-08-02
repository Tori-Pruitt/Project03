using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Health : MonoBehaviour
{
    public UnityEvent Damaged;
    // public property, public get private set
    [SerializeField]
    private int _maxHealth = 100;
    [SerializeField]
    private int _startingHealth = 100;

    private int _currentHealth;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    private void Awake()
    {
        _currentHealth = _startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Apply " + damageAmount + " damage");
        // ensure number is not 'negative'
        damageAmount = System.Math.Abs(damageAmount);
        // subtract damage from health
        _currentHealth -= damageAmount;
        // invoke the event
        Damaged.Invoke();

        // check to see if we've run out of health
        if(_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Debug.Log(gameObject.name + " is dead");
    }
}
