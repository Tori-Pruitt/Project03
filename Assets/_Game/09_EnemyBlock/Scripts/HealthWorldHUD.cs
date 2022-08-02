using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthWorldHUD : MonoBehaviour
{
    [SerializeField]
    private Health _health;
    [SerializeField]
    private Transform _healthBar;
    [SerializeField]
    private Image _healthFillImage;
    [SerializeField]
    private Vector3 _offset = new Vector3(0, 1, 0);

    private void Awake()
    {
        // remove from parent object, so we don't
        // inherit rotations
        transform.SetParent(null);
    }

    private void OnEnable()
    {
        _health.Damaged.AddListener(ScaleHealthBar);
    }

    private void OnDisable()
    {
        _health.Damaged.RemoveListener(ScaleHealthBar);
    }

    private void Start()
    {
        ScaleHealthBar();
    }

    private void Update()
    {
        // if there's no health, destory this object
        if(_health == null)
        {
            Destroy(gameObject);
            return;
        }
        // otherwise continue

        // reposition the HUD over the enemy
        transform.position = _health.transform.position + _offset;
    }

    // scale bar on a 0-1 ratio depending on amount and max
    public void ScaleHealthBar()
    {
        // store in floats so we can use decimal ratios
        float max = _health.MaxHealth;
        float current = _health.CurrentHealth;
        // calculate x scale between 0-1
        float newXScale = (1 / max) * current;
        // clamp it to make sure
        newXScale = Mathf.Clamp(newXScale, 0, 1);
        // scale it
        _healthFillImage.transform.localScale 
            = new Vector3(newXScale, 1, 1);
    }
}
