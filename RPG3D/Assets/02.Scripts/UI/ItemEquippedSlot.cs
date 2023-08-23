using RPG.Data;
using RPG.GameElements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI
{
    public class ItemEquippedSlot : MonoBehaviour
    {
        public BodyPart bodyPart;
        public int itemID;
        public Image image;

        public void Refresh(int itemID)
        {
            this.itemID = itemID;

            if (itemID > 0)
            {
                image.sprite = ItemDataRepository.instance.equipments[itemID].icon;
                image.color = Color.white;
            }
            else
            {
                image.color = Color.clear;
            }
        }

        public void Shadow(int itemID)
        {
            if (itemID > 0)
            {
                image.sprite = ItemDataRepository.instance.equipments[itemID].icon;
                image.color = new Color(1f, 1f, 1f, 0.7f);
            }
        }
    }
}