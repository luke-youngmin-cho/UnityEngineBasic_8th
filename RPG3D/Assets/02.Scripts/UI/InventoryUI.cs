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
        private InventoryPresenter _presenter;
        [SerializeField] private Transform _equipmentContent;
        [SerializeField] private Transform _spendContent;
        [SerializeField] private Transform _etcContent;
        [SerializeField] private InventorySlot _slotPrefab;
        private List<InventorySlot> _equipmentSlots = new List<InventorySlot>();
        private List<InventorySlot> _spendSlots = new List<InventorySlot>();
        private List<InventorySlot> _etcSlots = new List<InventorySlot>() ;
        [SerializeField] private CustomInputModule _inputModule;


        public override void InputAction()
        {
            base.InputAction();
            InventorySlot slot;

            if (Input.GetMouseButtonDown(0))
            {
                if (_inputModule.TryGetHovered<GraphicRaycaster, InventorySlot>(out slot))
                {
                    if (UIManager.instance.TryGet(out InventorySlotPicker picker))
                    {
                        picker.Show(slot.itemType, slot.slotIndex, _presenter.inventorySource.GetSlotData(slot.itemType, slot.slotIndex));
                    }
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                if (_inputModule.TryGetHovered<GraphicRaycaster, InventorySlot>(out slot))
                {
                    InventoryData.ItemSlotData slotData = _presenter.inventorySource.GetSlotData(slot.itemType, slot.slotIndex);
                    if (slotData.isEmpty == false &&
                        ItemDataRepository.instance.items.TryGetValue(slotData.itemID, out ItemData itemData) &&
                        itemData is UsableItemData)
                    {
                        ((UsableItemData)itemData).Use();
                        Debug.Log($"Used item in slot {slot.slotIndex}");
                    }
                }
            }
        }

        protected override void Awake()
        {
            base.Awake();
            _presenter = new InventoryPresenter();

            InventorySlot slot;
            var equipmentDatum = _presenter.inventorySource.equipmentSlotDatum;

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

            var spendDatum = _presenter.inventorySource.spendSlotDatum;

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

            var etcDatum = _presenter.inventorySource.etcSlotDatum;

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
        }

        private void Update()
        {
            InputAction();
        }
    }
}