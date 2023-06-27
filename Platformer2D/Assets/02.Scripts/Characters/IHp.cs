using System;
using UnityEngine;

public interface IHp
{
    float hp { get; set; }
    float hpMin { get; }
    float hpMax { get; }
    event Action<float> onHpChanged;
    event Action<float> onHpDecreased;
    event Action<float> onHpIncreased;
    event Action onHpMin;
    event Action onHpMax;

    public void Damage(GameObject damager, float amout);
    public void Heal(GameObject healer, float amount);
}
