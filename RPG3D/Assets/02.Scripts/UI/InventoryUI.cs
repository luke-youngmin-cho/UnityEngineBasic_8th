using RPG.DependencySources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        protected override void Awake()
        {
            base.Awake();
            _presenter = new InventoryPresenter();

            InventorySlot slot;
            var equipmentDatum = _presenter.inventorySource.equipmentSlotDatum;

            for (int i = 0; i < equipmentDatum.Count; i++)
            {
                slot = Instantiate(_slotPrefab, _equipmentContent);
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
                slot.slotIndex = i;
                slot.Refresh(etcDatum[i].itemID, etcDatum[i].itemNum);
                _etcSlots.Add(slot);
            }

            etcDatum.onItemChanged += (slotIndex, itemPair) =>
            {
                _etcSlots[slotIndex].Refresh(itemPair.itemID, itemPair.itemNum);
            };
        }
    }
}