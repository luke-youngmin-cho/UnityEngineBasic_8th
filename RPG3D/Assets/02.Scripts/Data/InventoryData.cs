using System;
using RPG.Collections;

namespace RPG.Data
{
    public enum ItemType
    {
        None,
        Equipment,
        Spend,
        ETC,
    }

    [Serializable]
    public class InventoryData : IDataModel
    {
        public int id { get; set; }

        [Serializable]
        public abstract class ItemSlotData : IComparable<ItemSlotData>
        {
            public bool isEmpty => itemNum <= 0;

            public int itemID;
            public int itemNum;

            public virtual int CompareTo(ItemSlotData other)
            {
                if (this.itemID == other.itemID &&
                    this.itemNum == other.itemNum)
                {
                    return 0;
                }
                else
                {
                    return this.itemNum > other.itemNum ? 1 : -1;
                }
            }
        }

        [Serializable]
        public class EquipmentSlotData : ItemSlotData
        {
            public int enhanceLevel;

            public override int CompareTo(ItemSlotData other)
            {
                if (this.itemID == other.itemID &&
                    this.itemNum == other.itemNum &&
                    this.enhanceLevel == ((EquipmentSlotData)other).enhanceLevel)
                {
                    return 0;
                }
                else
                {
                    return this.itemNum > other.itemNum ? 1 : -1;
                }
            }
        }

        [Serializable]
        public class SpendSlotData : ItemSlotData
        {

        }

        [Serializable]
        public class ETCSlotData : ItemSlotData
        {

        }

        public ObservableCollection<EquipmentSlotData> equipmentSlotDatum;
        public ObservableCollection<SpendSlotData> spendSlotDatum;
        public ObservableCollection<ETCSlotData> etcSlotDatum;

        public IDataModel ResetWithDefaults()
        {
            equipmentSlotDatum = new ObservableCollection<EquipmentSlotData>(40);
            spendSlotDatum = new ObservableCollection<SpendSlotData>(40);
            etcSlotDatum = new ObservableCollection<ETCSlotData>(40);
            return this;
        }
    }
}