using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.GameElements.Stats
{
    public enum StatType
    {
        HPMax,
        MPMax,
        STR,
        DEF,
    }

    public class Stat
    {
        public StatType type;
        public float value
        {
            get => _value;
            private set
            {
                _value = value;
                onValueChanged?.Invoke(value);
            }
        }
        private float _value;
        public event Action<float> onValueChanged;

        public float valueModified
        {
            get => _valueModified;
            private set
            {
                _valueModified = value;
                onValueModifiedChanged?.Invoke(value);
            }
        }
        private float _valueModified;
        public event Action<float> onValueModifiedChanged;

        public IEnumerator<StatModifier> modifiers => _modifiers.GetEnumerator();
        private List<StatModifier> _modifiers;

        public Stat(StatType type, float value)
        {
            this.type = type;
            this.value = value;
            this.valueModified = value;
        }


        public void AddModifer(StatModifier modifier)
        {
            _modifiers.Add(modifier);
            valueModified = CalcValueModified();
        }

        public void RemoveModifer(StatModifier modifier)
        {
            _modifiers.Remove(modifier);
            valueModified = CalcValueModified();
        }

        private float CalcValueModified()
        {
            float sumAddFlat = 0.0f;
            float sumAddPercent = 0.0f;
            float sumMulPercent = 0.0f;

            foreach (var modifier in _modifiers)
            {
                switch (modifier.modifyingOption)
                {
                    case StatModifyingOption.AddFlat:
                        {
                            sumAddFlat += modifier.value;
                        }
                        break;
                    case StatModifyingOption.AddPercent:
                        {
                            sumAddPercent += modifier.value;
                        }
                        break;
                    case StatModifyingOption.MulPercent:
                        {
                            sumMulPercent *= modifier.value;
                        }
                        break;
                    default:
                        break;
                }
            }

            return (_value + sumAddFlat) + (_value * sumAddPercent) + (_valueModified * sumMulPercent);
        }
    }
}