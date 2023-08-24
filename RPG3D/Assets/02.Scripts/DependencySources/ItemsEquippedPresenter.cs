using RPG.Collections;
using RPG.Data;
using RPG.UI;

namespace RPG.DependencySources
{
    public class ItemsEquippedPresenter
    {
        public class ItemsEquippedSource
        {
            public ObservableCollection<ItemsEquippedData.ItemEquippedSlotData> itemsEquippedSlotDatum;

            public ItemsEquippedSource()
            {
                if (DataModelManager.instance.TryGet(out ItemsEquippedData source))
                {
                    itemsEquippedSlotDatum
                        = new ObservableCollection<ItemsEquippedData.ItemEquippedSlotData>(source.slotDatum);
                    source.slotDatum.onItemChanged += (slotIndex, slotData) =>
                    {
                        itemsEquippedSlotDatum[slotIndex] = slotData;
                    };
                }
            }
        }
        public ItemsEquippedSource itemsEquippedSource;

        public class InventoryEquipmentSource
        {
            public ObservableCollection<InventoryData.EquipmentSlotData> equipmentSlotDatum;

            public InventoryEquipmentSource()
            {
                if (DataModelManager.instance.TryGet(out InventoryData source))
                {
                    equipmentSlotDatum = new ObservableCollection<InventoryData.EquipmentSlotData>(source.equipmentSlotDatum);
                    source.equipmentSlotDatum.onItemChanged += (slotIndex, slotData) =>
                    {
                        equipmentSlotDatum[slotIndex] = slotData;
                    };
                }
            }
        }
        public InventoryEquipmentSource inventoryEquipmentSource;


        public class UnequipCommand
        {
            private ItemsEquippedPresenter _presenter;

            public UnequipCommand(ItemsEquippedPresenter presenter)
            {
                _presenter = presenter;
            }

            public bool CanExecute()
            {
                return _presenter.inventoryEquipmentSource.equipmentSlotDatum.FindIndex(x => x.isEmpty) >= 0;
            }

            public void Execute(ItemEquippedSlot slot)
            {
                var equippedItemData = ItemDataRepository.instance.equipments[slot.itemID];
                var itemEquippedSlotData = _presenter.itemsEquippedSource.itemsEquippedSlotDatum[(int)equippedItemData.bodyPart];
                var inventoryEmptySlotIndex= _presenter.inventoryEquipmentSource.equipmentSlotDatum.FindIndex(x => x.isEmpty);

                if (DataModelManager.instance.TryGet(out InventoryData inventoryData))
                {
                    inventoryData.equipmentSlotDatum[inventoryEmptySlotIndex] = new InventoryData.EquipmentSlotData()
                    {
                        itemID = itemEquippedSlotData.itemID,
                        enhanceLevel = itemEquippedSlotData.enhanceLevel,
                        itemNum = 1
                    };
                }

                if (DataModelManager.instance.TryGet(out ItemsEquippedData itemsEquippedData))
                {
                    itemsEquippedData.slotDatum[(int)equippedItemData.bodyPart] = new ItemsEquippedData.ItemEquippedSlotData()
                    {
                        part = equippedItemData.bodyPart,
                        itemID = 0,
                        enhanceLevel = 0,
                    };
                }
            }

            public bool TryExecute(ItemEquippedSlot slot)
            {
                if (CanExecute())
                {
                    Execute(slot);
                    return true;
                }

                return false;
            }
        }
        public UnequipCommand unequipCommand;


        public ItemsEquippedPresenter()
        {
            itemsEquippedSource = new ItemsEquippedSource();
            inventoryEquipmentSource = new InventoryEquipmentSource();
            unequipCommand = new UnequipCommand(this);
        }
    }
}