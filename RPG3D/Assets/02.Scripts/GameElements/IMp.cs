using RPG.FSM;
using System;
using UnityEngine;

namespace RPG.GameElements
{
    public interface IMp
    {
        float mp { get; set; }
        float mpMax { get; }
        float mpMin { get; }

        event Action<float> onMpChanged; // 변경된 값
        event Action<float> onMpRecovered; // 회복된 양
        event Action<float> onMpDepleted; // 감소된 양
        event Action onMpMax;
        event Action onMpMin;


        void RecoverMp(MachineManager characterMachine, float amount);
        void DepleteMp(MachineManager characterMachine, float amount);
    }
}