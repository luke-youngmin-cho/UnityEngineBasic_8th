using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatusUI : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;
    [SerializeField] private TMP_Text _hp;
    [SerializeField] private TMP_Text _hpMax;

    private void Start()
    {
        Player player = Player.instance;

        _hpBar.minValue = 0.0f;
        _hpBar.maxValue = player.hpMax;
        _hpBar.value = player.hp;
        _hp.text = ((int)player.hp).ToString();
        _hpMax.text = ((int)player.hpMax).ToString();
        player.onHpChanged += (value) =>
        {
            _hpBar.value = value;
            _hp.text = ((int)value).ToString();
        };
    }
}
