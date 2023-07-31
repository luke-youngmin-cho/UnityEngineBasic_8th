using RPG.Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI
{
    public class InventorySlot : MonoBehaviour
    {
        [HideInInspector] public ItemType itemType;
        [HideInInspector] public int slotIndex;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _num;

        public void Refresh(int itemID, int num)
        {
            if (ItemDataRepository.instance.items.TryGetValue(itemID, out ItemData data))
            {
                _icon.sprite = data.icon;
                _num.text = num > 1 ? num.ToString() : string.Empty;
            }
            else
            {
                _icon.sprite = null;
                _num.text = string.Empty;
            }
        }
    }
}