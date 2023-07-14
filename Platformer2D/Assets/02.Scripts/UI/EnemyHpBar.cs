using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    private void Start()
    {
        Enemy target = GetComponentInParent<Enemy>();
        Slider hpBar = GetComponentInChildren<Slider>();
        hpBar.minValue = 0.0f;
        hpBar.maxValue = target.hpMax;
        hpBar.value = target.hp;

        target.onHpChanged += (value) =>
        {
            hpBar.value = value;
        };

        Movement movement = target.GetComponent<Movement>();
        movement.onDirectionChanged += (value) =>
        {
            transform.localEulerAngles = value > 0 ? Vector3.zero : new Vector3(0.0f, 180.0f, 0.0f);
        };
    }
}
