using RPG.GameElements.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour 를 굳이 상속받을 필요는 없음.. 그냥 스텟조정자를 어떻게 가지고있어야하는지에 대한
// 데이터만 ScriptableObject 같은곳에 리스트로 넣어두고 런타임에 StatModifier 생성해서 써도됨.

public enum StatModifyingOption
{
    None,
    AddFlat,
    AddPercent,
    MulPercent,
}

public class StatModifier : MonoBehaviour
{
    public StatType type;
    public StatModifyingOption modifyingOption;
    public float value;
}
