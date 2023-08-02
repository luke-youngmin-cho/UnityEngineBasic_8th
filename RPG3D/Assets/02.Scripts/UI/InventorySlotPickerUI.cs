using RPG.Data;
using RPG.DependencySources;
using RPG.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI
{
    public class InventorySlotPickerUI : UIMonoBehaviour
    {
        [SerializeField] private Image _preview;
        private ItemType _pickedType;
        private int _pickedIndex;
        private InventoryData.ItemSlotData _pickedData;
        private InventoryPresenter _presenter;

        public void Show(ItemType type, int index, InventoryData.ItemSlotData slotData)
        {
            base.Show();
            _pickedType = type;
            _pickedIndex = index;
            _pickedData = slotData;
            if (ItemDataRepository.instance.items.TryGetValue(slotData.itemID, out ItemData data))
            {
                _preview.sprite = data.icon;
            }
            else
            {
                _preview.sprite = null;
            }
        }

        public override void InputAction()
        {
            base.InputAction();

            if (Input.GetMouseButtonDown(0))
            {
                // UI 클릭시
                if (inputModule.TryGetHovered<GraphicRaycaster>(out List<GameObject> hovered))
                {
                    foreach (var go in hovered)
                    {
                        if (go.TryGetComponent(out InventorySlot slot))
                        {
                            if (slot.itemType == _pickedType)
                            {
                                if (slot.slotIndex != _pickedIndex)
                                {
                                    _presenter.swapCommand.TryExecute(_pickedType, _pickedIndex, slot.slotIndex);
                                }

                                Hide();
                                return;
                            }
                        }
                    }
                }
                //World 클릭시
                else
                {
                    if (_presenter.dropCommand.TryExecute(_pickedType, _pickedIndex, _pickedData.itemNum))
                    {

                    }
                    Hide();
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Hide();
            }
        }

        protected override void Start()
        {
            base.Start();
            if (UIManager.instance.TryGet(out InventoryUI inventoryUI))
            {
                _presenter = inventoryUI.presenter;
            }
        }

        override protected void Update()
        {
            base.Update();
            _preview.transform.position = Input.mousePosition;
        }
    }

}
