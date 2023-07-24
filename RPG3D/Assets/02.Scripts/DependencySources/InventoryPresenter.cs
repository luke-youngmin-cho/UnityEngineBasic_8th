using RPG.Collections;
using RPG.Data;
using System.Linq;
using UnityEngine;

namespace RPG.DependencySources
{
    public class InventoryPresenter
    {
        public class InventorySource
        {
            public ObservableCollection<InventoryData.EquipmentSlotData> equipmentSlotDatum;
            public ObservableCollection<InventoryData.SpendSlotData> spendSlotDatum;
            public ObservableCollection<InventoryData.ETCSlotData> etcSlotDatum;

            public InventorySource()
            {
                if (DataModelManager.instance.TryGet(out InventoryData source))
                {
                    equipmentSlotDatum = new ObservableCollection<InventoryData.EquipmentSlotData>(source.equipmentSlotDatum);
                    source.equipmentSlotDatum.onItemChanged += (slotIndex, slotData) =>
                    {
                        equipmentSlotDatum[slotIndex] = slotData;
                    };
                    source.equipmentSlotDatum.onItemAdded += (slotIndex, slotData) =>
                    {
                        if (equipmentSlotDatum.Count == slotIndex)
                            equipmentSlotDatum.Add(slotData);
                        else
                            throw new System.Exception("[InventoryPresenter.InventorySource] : Failed to add item, data is unmatched");
                    };
                    source.equipmentSlotDatum.onItemRemoved += (slotIndex, slotData) =>
                    {
                        if (equipmentSlotDatum.Count == source.equipmentSlotDatum.Count + 1)
                        {
                            if (equipmentSlotDatum[slotIndex].CompareTo(slotData) == 0)
                                equipmentSlotDatum.RemoveAt(slotIndex);
                            else
                                throw new System.Exception("[InventoryPresenter.InventorySource] : Failed to remove item, data is unmatched");
                        }
                        else
                            throw new System.Exception("[InventoryPresenter.InventorySource] : Failed to remove item, data is unmatched");
                    };

                    spendSlotDatum = new ObservableCollection<InventoryData.SpendSlotData>(source.spendSlotDatum);
                    source.spendSlotDatum.onItemChanged += (slotIndex, slotData) =>
                    {
                        spendSlotDatum[slotIndex] = slotData;
                    };
                    source.spendSlotDatum.onItemAdded += (slotIndex, slotData) =>
                    {
                        if (spendSlotDatum.Count == slotIndex)
                            spendSlotDatum.Add(slotData);
                        else
                            throw new System.Exception("[InventoryPresenter.InventorySource] : Failed to add item, data is unmatched");
                    };
                    source.spendSlotDatum.onItemRemoved += (slotIndex, slotData) =>
                    {
                        if (spendSlotDatum.Count == source.spendSlotDatum.Count + 1)
                        {
                            if (spendSlotDatum[slotIndex].CompareTo(slotData) == 0)
                                spendSlotDatum.RemoveAt(slotIndex);
                            else
                                throw new System.Exception("[InventoryPresenter.InventorySource] : Failed to remove item, data is unmatched");
                        }
                        else
                            throw new System.Exception("[InventoryPresenter.InventorySource] : Failed to remove item, data is unmatched");
                    };

                    etcSlotDatum = new ObservableCollection<InventoryData.ETCSlotData>(source.etcSlotDatum);
                    source.etcSlotDatum.onItemChanged += (slotIndex, slotData) =>
                    {
                        etcSlotDatum[slotIndex] = slotData;
                    };
                    source.etcSlotDatum.onItemAdded += (slotIndex, slotData) =>
                    {
                        if (etcSlotDatum.Count == slotIndex)
                            etcSlotDatum.Add(slotData);
                        else
                            throw new System.Exception("[InventoryPresenter.InventorySource] : Failed to add item, data is unmatched");
                    };
                    source.etcSlotDatum.onItemRemoved += (slotIndex, slotData) =>
                    {
                        if (etcSlotDatum.Count == source.etcSlotDatum.Count + 1)
                        {
                            if (etcSlotDatum[slotIndex].CompareTo(slotData) == 0)
                                etcSlotDatum.RemoveAt(slotIndex);
                            else
                                throw new System.Exception("[InventoryPresenter.InventorySource] : Failed to remove item, data is unmatched");
                        }
                        else
                            throw new System.Exception("[InventoryPresenter.InventorySource] : Failed to remove item, data is unmatched");
                    };
                }
                else
                {
                    throw new System.Exception($"[InventoryData.InventorySource] : Failed to initailize sources.");
                }
            }
        }
        public InventorySource inventorySource;

        public class SwapCommand
        {
            private InventoryPresenter _presenter;

            public SwapCommand(InventoryPresenter presenter) => _presenter = presenter;

            public bool canExecute(ItemType type, int slotIndex1, int slotIndex2)
            {
                if (slotIndex1 == slotIndex2)
                    return false;

                switch (type)
                {
                    case ItemType.Equipment:
                        {
                            int count = _presenter.inventorySource.equipmentSlotDatum.Count;
                            return slotIndex1 < count &&
                                   slotIndex2 < count;
                        }
                    case ItemType.Spend:
                        {
                            int count = _presenter.inventorySource.spendSlotDatum.Count;
                            return slotIndex1 < count &&
                                   slotIndex2 < count;
                        }                        
                    case ItemType.ETC:
                        {
                            int count = _presenter.inventorySource.etcSlotDatum.Count;
                            return slotIndex1 < count &&
                                   slotIndex2 < count;
                        }
                    default:
                        throw new System.Exception("[InventoryPresenter.SwapCommand] : Wrong item type");
                }

            }
        }

        public InventoryPresenter()
        {
            inventorySource = new InventorySource();
        }
    }
}