using RPG.Singletons;
using System;
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

    // Repository pattern 
    public class DataModelManager : SingletonBase<DataModelManager>
    {
        private Dictionary<Type, IDataModel> _dataModelsByType;
        private Dictionary<DataCategory, IDataModel> _dataModelsByCategory;

        public bool TryGet<T>(out T dataModel)
            where T : IDataModel
        {
            if (_dataModelsByType.TryGetValue(typeof(T), out IDataModel result))
            {
                dataModel = (T)result;
                return true;
            }

            dataModel = default(T);
            return false;
        }

        public bool TryGet(DataCategory category, out IDataModel dataModel)
        {
            return _dataModelsByCategory.TryGetValue(category, out dataModel);
        }


        public void Register<T>(DataCategory category)
            where T : IDataModel
        {
            if (_dataModelsByType.ContainsKey(typeof(T)))
                throw new Exception($"[DataModelManager] : Failed to register. {typeof(T)} is already exist. ");

            T dataModel = Load<T>();
            _dataModelsByType.Add(typeof(T), dataModel);
            _dataModelsByCategory.Add(category, dataModel);
        }

        public T Load<T>()
             where T : IDataModel
        {
            string dataPath = $"{Application.persistentDataPath}/{typeof(T).Name}.json";

            T data;
            if (System.IO.File.Exists(dataPath))
            {
                data = JsonUtility.FromJson<T>(System.IO.File.ReadAllText(dataPath));
            }
            else
            {
                data = (T)Activator.CreateInstance<T>().ResetWithDefaults();
                System.IO.File.WriteAllText(dataPath, JsonUtility.ToJson(data));
            }

            data.Init();
            return data;
        }

        public void Save<T>()
        {
            string dataPath = $"{Application.persistentDataPath}/{typeof(T).Name}.json";
            System.IO.File.WriteAllText(dataPath, JsonUtility.ToJson(_dataModelsByType[typeof(T)]));
        }

        protected override void Init()
        {
            base.Init();
            _dataModelsByType = new Dictionary<Type, IDataModel>();
            _dataModelsByCategory = new Dictionary<DataCategory, IDataModel>();

            Register<InventoryData>(DataCategory.Inventory);
        }
    }
}