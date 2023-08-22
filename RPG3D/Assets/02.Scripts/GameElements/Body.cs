using RPG.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.GameElements
{
    public enum BodyPart
    {
        None,
        Head,
        Top,
        Bottom,
        Feet,
        RightHand,
        LeftHand,
        TwoHand
    }

    public class Body : MonoBehaviour
    {
        public List<UKeyValuePair<BodyPart, Transform>> bodyParts;
        

        private void Start()
        {
            if (DataModelManager.instance.TryGet(out ItemsEquippedData itemsEquippedData))
            {
                // 특정 슬롯의 장착아이템 데이터 바뀌었을때
                itemsEquippedData.slotDatum.onItemChanged += (slotIndex, slotData) =>
                {
                    // 기존에 장착된거 있으면 파괴
                    if (bodyParts[slotIndex].Value.childCount == 1)
                    {
                        Destroy(bodyParts[slotIndex].Value.GetChild(0).gameObject);
                    }

                    // 새로 장착할 거 있으면 해당 모델 생성
                    if (slotData.isEmpty == false)
                    {
                        Instantiate(ItemDataRepository.instance.equipments[slotData.itemID].model,
                                    bodyParts[slotIndex].Value);
                    }
                };
            }
        }
    }
}