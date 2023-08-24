using RPG.Data;
using RPG.DependencySources;
using RPG.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RPG.UI
{
    public class InventoryUI : UIMonoBehaviour
    {
        public InventoryPresenter presenter;
        [SerializeField] private Transform _equipmentContent;
        [SerializeField] private Transform _spendContent;
        [SerializeField] private Transform _etcContent;
        [SerializeField] private InventorySlot _slotPrefab;
        private List<InventorySlot> _equipmentSlots = new List<InventorySlot>();
        private List<InventorySlot> _spendSlots = new List<InventorySlot>();
        private List<InventorySlot> _etcSlots = new List<InventorySlot>() ;
        [SerializeField] private Button _close;

        public override void InputAction()
        {
            base.InputAction();
            InventorySlot slot;

            if (Input.GetMouseButtonDown(0))
            {
                if (inputModule.TryGetHovered<GraphicRaycaster, InventorySlot>(out slot))
                {
                    InventoryData.ItemSlotData slotData = presenter.inventorySource.GetSlotData(slot.itemType, slot.slotIndex);
                    if (slotData.itemNum > 0 &&
                        UIManager.instance.TryGet(out InventorySlotPickerUI picker))
                    {
                        picker.Show(slot.itemType, slot.slotIndex, slotData);
                    }
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                if (inputModule.TryGetHovered<GraphicRaycaster, InventorySlot>(out slot))
                {
                    InventoryData.ItemSlotData slotData = presenter.inventorySource.GetSlotData(slot.itemType, slot.slotIndex);
                    if (slotData.isEmpty == false &&
                        ItemDataRepository.instance.items.TryGetValue(slotData.itemID, out ItemData itemData) &&
                        itemData is UsableItemData)
                    {
                        if (itemData is EquipmentItemData)
                        {
                            ((EquipmentItemData)itemData).Use(slot);
                        }
                        else
                        {
                            ((UsableItemData)itemData).Use();
                        }
                        Debug.Log($"Used item in slot {slot.slotIndex}");
                    }
                }
            }
        }

        protected override void Awake()
        {
            base.Awake();
            presenter = new InventoryPresenter();

            InventorySlot slot;
            var equipmentDatum = presenter.inventorySource.equipmentSlotDatum;

            for (int i = 0; i < equipmentDatum.Count; i++)
            {
                slot = Instantiate(_slotPrefab, _equipmentContent);
                slot.itemType = Data.ItemType.Equipment;
                slot.slotIndex = i;
                slot.Refresh(equipmentDatum[i].itemID, equipmentDatum[i].itemNum);
                _equipmentSlots.Add(slot);
            }

            equipmentDatum.onItemChanged += (slotIndex, itemPair) =>
            {
                _equipmentSlots[slotIndex].Refresh(itemPair.itemID, itemPair.itemNum);
            };

            var spendDatum = presenter.inventorySource.spendSlotDatum;

            for (int i = 0; i < spendDatum.Count; i++)
            {
                slot = Instantiate(_slotPrefab, _spendContent);
                slot.itemType = Data.ItemType.Spend;
                slot.slotIndex = i;
                slot.Refresh(spendDatum[i].itemID, spendDatum[i].itemNum);
                _spendSlots.Add(slot);
            }

            spendDatum.onItemChanged += (slotIndex, itemPair) =>
            {
                _spendSlots[slotIndex].Refresh(itemPair.itemID, itemPair.itemNum);
            };

            var etcDatum = presenter.inventorySource.etcSlotDatum;

            for (int i = 0; i < etcDatum.Count; i++)
            {
                slot = Instantiate(_slotPrefab, _etcContent);
                slot.itemType = Data.ItemType.ETC;
                slot.slotIndex = i;
                slot.Refresh(etcDatum[i].itemID, etcDatum[i].itemNum);
                _etcSlots.Add(slot);
            }

            etcDatum.onItemChanged += (slotIndex, itemPair) =>
            {
                _etcSlots[slotIndex].Refresh(itemPair.itemID, itemPair.itemNum);
            };

            _close.onClick.AddListener(Hide);
        }
    }
}