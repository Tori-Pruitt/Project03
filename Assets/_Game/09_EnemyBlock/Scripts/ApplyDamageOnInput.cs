using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamageOnInput : MonoBehaviour
{
    [SerializeField]
    private Health _objectWithHealth;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _objectWithHealth.TakeDamage(15);
        }
    }
}
