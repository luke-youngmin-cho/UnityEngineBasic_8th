using RPG.Collections;
using RPG.Data;
using System;
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
            private InventoryData _inventoryData;

            public SwapCommand(InventoryPresenter presenter)
            {
                _presenter = presenter;
                if (DataModelManager.instance.TryGet(out _inventoryData) == false)
                    throw new System.Exception("[InventoryPresenter.SwapCommand] : Failed to cache inventory data model");
            }

            public bool CanExecute(ItemType type, int slotIndex1, int slotIndex2)
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

            public void Execute(ItemType type, int slotIndex1, int slotIndex2)
            {
                switch (type)
                {
                    case ItemType.Equipment:
                        {
                            _inventoryData.equipmentSlotDatum.Swap(slotIndex1, slotIndex2);
                        }
                        break;
                    case ItemType.Spend:
                        {
                            _inventoryData.spendSlotDatum.Swap(slotIndex1, slotIndex2);
                        }
                        break;
                    case ItemType.ETC:
                        {
                            _inventoryData.etcSlotDatum.Swap(slotIndex1, slotIndex2);
                        }
                        break;
                    default:
                        throw new System.Exception("[InventoryPresenter.SwapCommand] : Wrong item type");
                }
            }

            public bool TryExecute(ItemType type, int slotIndex1, int slotIndex2)
            {
                if (CanExecute(type, slotIndex1, slotIndex2))
                {
                    Execute(type, slotIndex1, slotIndex2);
                    return true;
                }

                return false;
            }
        }
        public SwapCommand swapCommand;

        public class DropCommand
        {
            private InventoryPresenter _presenter;
            private InventoryData _inventoryData;

            public DropCommand(InventoryPresenter presenter)
            {
                _presenter = presenter;
                if (DataModelManager.instance.TryGet(out _inventoryData) == false)
                    throw new Exception("[InventoryPresenter.SwapCommand] : Failed to cache inventory data model");
            }

            public bool CanExecute(ItemType type, int slotIndex, int num)
            {
                if (slotIndex < 0 ||
                    num < 0)
                    return false;

                switch (type)
                {
                    case ItemType.Equipment:
                        {
                            if (slotIndex >= _presenter.inventorySource.equipmentSlotDatum.Count)
                                return false;

                            if (num > _presenter.inventorySource.equipmentSlotDatum[slotIndex].itemNum)
                                return false;
                        }
                        break;
                    case ItemType.Spend:
                        {
                            if (slotIndex >= _presenter.inventorySource.spendSlotDatum.Count)
                                return false;

                            if (num > _presenter.inventorySource.spendSlotDatum[slotIndex].itemNum)
                                return false;
                        }
                        break;
                    case ItemType.ETC:
                        {
                            if (slotIndex >= _presenter.inventorySource.etcSlotDatum.Count)
                                return false;

                            if (num > _presenter.inventorySource.etcSlotDatum[slotIndex].itemNum)
                                return false;
                        }
                        break;
                    default:
                        throw new Exception("[InventoryPresenter.SwapCommand] : Wrong item type");
                }

                return true;
            }

            public void Execute(ItemType type, int slotIndex, int num)
            {
                switch (type)
                {
                    case ItemType.Equipment:
                        {
                            InventoryData.EquipmentSlotData slotData = _presenter.inventorySource.equipmentSlotDatum[slotIndex];
                            _inventoryData.equipmentSlotDatum.Change(slotIndex,
                                                                     new InventoryData.EquipmentSlotData()
                                                                     {
                                                                         enhanceLevel = slotData.enhanceLevel,
                                                                         itemID = slotData.itemID,
                                                                         itemNum = slotData.itemNum - num
                                                                     });
                        }
                        break;
                    case ItemType.Spend:
                        {
                            InventoryData.SpendSlotData slotData = _presenter.inventorySource.spendSlotDatum[slotIndex];
                            _inventoryData.spendSlotDatum.Change(slotIndex,
                                                                 new InventoryData.SpendSlotData()
                                                                 {
                                                                     itemID = slotData.itemID,
                                                                     itemNum = slotData.itemNum - num
                                                                 });
                        }
                        break;
                    case ItemType.ETC:
                        {
                            InventoryData.ETCSlotData slotData = _presenter.inventorySource.etcSlotDatum[slotIndex];
                            _inventoryData.etcSlotDatum.Change(slotIndex,
                                                               new InventoryData.ETCSlotData()
                                                               {
                                                                   itemID = slotData.itemID,
                                                                   itemNum = slotData.itemNum - num
                                                               });
                        }
                        break;
                    default:
                        throw new Exception("[InventoryPresenter.SwapCommand] : Wrong item type");
                }

                // todo -> Battle field ¿¡ Item »ý¼º
            }

            public bool TryExecute(ItemType type, int slotIndex, int num)
            {
                if (CanExecute(type, slotIndex, num))
                {
                    Execute(type, slotIndex, num);
                    return true;
                }

                return false;
            }
        }
        public DropCommand dropCommand;

        public class UseCommand
        {
            private InventoryPresenter _presenter;

            public UseCommand(InventoryPresenter presenter)
            {
                _presenter = presenter;
            }

            public bool CanExecute(ItemType type, int slotIndex)
            {
                return true;
            }

            public void Execute(ItemType type, int slotIndex)
            {

            }

            public bool TryExecute(ItemType type, int slotIndex)
            {
                if (CanExecute(type, slotIndex))
                {
                    Execute(type, slotIndex);
                    return true;
                }

                return false;
            }
        }
        public UseCommand useCommand;

        public InventoryPresenter()
        {
            inventorySource = new InventorySource();
            swapCommand = new SwapCommand(this);
            dropCommand = new DropCommand(this);
            useCommand = new UseCommand(this);
        }
    }
}