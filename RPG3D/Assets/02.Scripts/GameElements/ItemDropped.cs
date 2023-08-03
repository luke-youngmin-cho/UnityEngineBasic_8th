using RPG.Collections;
using RPG.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class ItemDropped : MonoBehaviour
{
    private int _itemID;
    private int _itemNum;
    private MeshFilter _filter;
    private MeshRenderer _renderer;
    private bool _hasPickedUp;

    public static ItemDropped Create(int itemID, int itemNum, Vector3 position)
    {
        GameObject gameObject = new GameObject("ItemDropped");
        gameObject.transform.position = position;
        gameObject.layer = LayerMask.NameToLayer("ItemDropped");
        gameObject.AddComponent<BoxCollider>().isTrigger = true;
        ItemDropped itemDropped = gameObject.AddComponent<ItemDropped>();
        GameObject child = new GameObject("Renderer");
        child.transform.SetParent(gameObject.transform);
        itemDropped._filter = child.AddComponent<MeshFilter>();
        itemDropped._renderer = child.AddComponent<MeshRenderer>();

        itemDropped._filter.sharedMesh = ItemDataRepository.instance[itemID].model.GetComponent<MeshFilter>().sharedMesh;
        itemDropped._renderer.sharedMaterials = ItemDataRepository.instance[itemID].model.GetComponent<MeshRenderer>().sharedMaterials;

        itemDropped._itemID = itemID;
        itemDropped._itemNum = itemNum;
        return itemDropped;
    }


    public void PickUp()
    {
        if (_hasPickedUp)
            return;

        _hasPickedUp = true;

        if (DataModelManager.instance.TryGet(out InventoryData dataModel))
        {
            ItemData itemData = ItemDataRepository.instance[_itemID];
            int remains = 0;

            switch (itemData.type)
            {
                case ItemType.Equipment:
                    remains = FillInventoryData(dataModel.equipmentSlotDatum, itemData);
                    break;
                case ItemType.Spend:
                    remains = FillInventoryData(dataModel.spendSlotDatum, itemData);
                    break;
                case ItemType.ETC:
                    remains = FillInventoryData(dataModel.etcSlotDatum, itemData);
                    break;
                default:
                    break;
            }

            if (remains > 0)
            {
                _itemNum = remains;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Fills Inventory Data and returns remains
    /// </summary>
    /// <returns> remains </returns>
    private int FillInventoryData<T>(ObservableCollection<T> slotDatum, ItemData itemData)
        where T : InventoryData.ItemSlotData
    {
        int remains = _itemNum;

        for (int i = 0; i < slotDatum.Count; i++)
        {
            var slotData = slotDatum[i];

            if (slotData.isEmpty ||
                (slotData.itemID == _itemID && slotData.itemNum < itemData.numMax))
            {
                int expected = remains - itemData.numMax + slotData.itemNum;
                if (expected > 0)
                {
                    slotData.itemNum = itemData.numMax;
                    slotDatum[i] = slotData;
                    remains = expected;
                }
                else
                {
                    slotData.itemNum = slotData.itemNum + remains;
                    slotDatum[i] = slotData;
                    remains = 0;
                }
            }
        }

        return remains;
    }

}
