using RPG.Collections;
using RPG.Data;

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

        public ItemsEquippedPresenter()
        {
            itemsEquippedSource = new ItemsEquippedSource();
        }
    }
}