using RPG.Singletons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Data
{
    public enum DataCategory
    {
        None,
        Inventory,
    }

    public class DataModelManager : SingletonBase<DataModelManager>
    {
        private Dictionary<DataCategory, IDataModel> _dataModels;


        protected override void Init()
        {
            base.Init();
            _dataModels = new Dictionary<DataCategory, IDataModel>
            {
                {DataCategory.Inventory, new InventoryData(36) },
            };

            _dataModels[DataCategory.Inventory].id = (int)DataCategory.Inventory;
        }
    }
}