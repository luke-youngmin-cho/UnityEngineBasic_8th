using RPG.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI
{

    public class InventorySlotPicker : UIMonoBehaviour
    {
        [SerializeField] private Image _preview;
        private ItemType _pickedType;
        private int _pickedIndex;
        private InventoryData.ItemSlotData _pickedData;

        public void Show(ItemType type, int index, InventoryData.ItemSlotData slotData)
        {
            base.Show();
            _pickedType = type;
            _pickedIndex = index;
            _pickedData = slotData;
            _preview.sprite = ItemDataRepository.instance[slotData.itemID].icon;
        }

        private void Update()
        {
            _preview.transform.position = Input.mousePosition;
        }
    }
}