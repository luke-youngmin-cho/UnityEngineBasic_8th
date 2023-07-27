using RPG.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Data
{
    public class ItemDataRepository : MonoBehaviour
    {
        public static ItemDataRepository instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Instantiate(Resources.Load<ItemDataRepository>("ItemDataRepository"));
                }
                return _instance;
            }
        }
        private static ItemDataRepository _instance;

        public ItemData this[int id] => _itemDataDictionary[id];
        public Dictionary<int, EquipmentItemData> equipments => _equipmentItemDataDictionary;
        public Dictionary<int, SpendItemData> spends => _spendItemDataDictionary;
        public Dictionary<int, ETCItemData> etcs => _etcItemDataDictionary;
        public Dictionary<int, ItemData> items => _itemDataDictionary;

        private Dictionary<int, EquipmentItemData> _equipmentItemDataDictionary;
        private Dictionary<int, SpendItemData> _spendItemDataDictionary;
        private Dictionary<int, ETCItemData> _etcItemDataDictionary;
        private Dictionary<int, ItemData> _itemDataDictionary;
        [SerializeField] private List<EquipmentItemData> _equipmentItemDatum;
        [SerializeField] private List<SpendItemData> _spendItemDatum;
        [SerializeField] private List<ETCItemData> _etcItemDatum;

        private void Awake()
        {
            _equipmentItemDataDictionary = new Dictionary<int, EquipmentItemData>();
            _spendItemDataDictionary = new Dictionary<int, SpendItemData>();
            _etcItemDataDictionary = new Dictionary<int, ETCItemData>();
            _itemDataDictionary = new Dictionary<int, ItemData>();

            foreach (var item in _equipmentItemDatum)
            {
                _equipmentItemDataDictionary.Add(item.id, item);
                _itemDataDictionary.Add(item.id, item);
            }

            foreach (var item in _spendItemDatum)
            {
                _spendItemDataDictionary.Add(item.id, item);
                _itemDataDictionary.Add(item.id, item);
            }

            foreach (var item in _etcItemDatum)
            {
                _etcItemDataDictionary.Add(item.id, item);
                _itemDataDictionary.Add(item.id, item);
            }
        }
    }
}