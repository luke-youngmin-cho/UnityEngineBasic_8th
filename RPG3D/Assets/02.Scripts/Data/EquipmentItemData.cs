using RPG.GameElements;
using RPG.UI;
using UnityEngine;

namespace RPG.Data
{
    [CreateAssetMenu(fileName = "new EquipmentItemData", menuName = "RPG/Data/Create EquipmentItemData")]
    public class EquipmentItemData : UsableItemData
    {
        public BodyPart bodyPart;

        public void Use(InventorySlot slot)
        {
            if (DataModelManager.instance.TryGet(out InventoryData inventoryData) &&
                DataModelManager.instance.TryGet(out ItemsEquippedData itemsEquippedData))
            {
                // 장착 하려고하는 아이템 데이터
                EquipmentItemData itemToEquipData = ItemDataRepository.instance[slot.itemID] as EquipmentItemData;
                // 장착 되어있던 아이템 데이터 
                int itemEquippedID = itemsEquippedData.slotDatum[(int)itemToEquipData.bodyPart].itemID;
                
                // 장착 하려고하는 인벤토리 슬롯 데이터
                InventoryData.EquipmentSlotData inventorySlotData = inventoryData.equipmentSlotDatum[slot.slotIndex];

                // 장착 되어있던 아이템이 있으면
                if (ItemDataRepository.instance.equipments.TryGetValue(itemEquippedID, out EquipmentItemData itemEquippedData))
                {
                    // 장착 되어어있던 슬롯 데이터
                    ItemsEquippedData.ItemEquippedSlotData equippedSlotData = itemsEquippedData.slotDatum[(int)itemEquippedData.bodyPart];

                    // 장착 되어있던거 장착하려는 아이템위치의 슬롯에다가 씀.
                    inventoryData.equipmentSlotDatum[slot.slotIndex] = new InventoryData.EquipmentSlotData()
                    {
                        itemID = equippedSlotData.itemID,
                        itemNum = 1,
                        enhanceLevel = equippedSlotData.enhanceLevel
                    };
                }
                // 장착 되어있던 아이템이 없으면
                else
                {
                    inventoryData.equipmentSlotDatum[slot.slotIndex] = new InventoryData.EquipmentSlotData();
                }

                // 장착하려는 인벤토리슬롯의 장비를 장비창 데이터에 씀
                itemsEquippedData.slotDatum[(int)itemToEquipData.bodyPart] = new ItemsEquippedData.ItemEquippedSlotData()
                {
                    part = itemToEquipData.bodyPart,
                    itemID = inventorySlotData.itemID,
                    enhanceLevel = inventorySlotData.enhanceLevel,
                };

            }
        }

        public override void Use()
        {
            throw new System.NotImplementedException();
        }
    }
}
