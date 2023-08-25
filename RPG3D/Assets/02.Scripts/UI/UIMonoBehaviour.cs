using RPG.EventSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RPG.UI
{
    [RequireComponent(typeof(Canvas))]
    public class UIMonoBehaviour : MonoBehaviour, IUI
    {
        public bool inputActionEnalbed { get; set; }
        protected UIManager manager;
        protected Canvas canvas;
        [Header("Options")]
        [SerializeField] private bool hideWhenClickOutside;
        protected CustomInputModule inputModule;

        public int sortingOrder
        {
            get => canvas.sortingOrder;
            set => canvas.sortingOrder = value;
        }

        public event Action onShow;
        public event Action onHide;

        public void Show()
        {
            manager.Push(this);
            gameObject.SetActive(true);
            onShow?.Invoke();
        }

        public void Hide()
        {
            manager.Pop(this);
            gameObject.SetActive(false);
            onHide?.Invoke();
        }

        public void ShowUnmanaged()
        {
            gameObject.SetActive(true);
            onShow?.Invoke();
        }

        public void HideUnmanaged()
        {
            gameObject.SetActive(false);
            onHide?.Invoke();
        }

        public virtual void InputAction()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                if (inputModule.TryGetHovered<GraphicRaycaster, CanvasRenderer>(out CanvasRenderer canvasRenderer))
                {
                    if (canvasRenderer.transform.root.TryGetComponent(out UIMonoBehaviour ui) &&
                        ui != this)
                    {
                        UIManager.instance.Push(ui);
                        ui.InputAction();
                    }
                }
            }
        }

        protected virtual void Awake()
        {
            canvas = GetComponent<Canvas>();
            manager = UIManager.instance;
            manager.Register(this);

            if (hideWhenClickOutside)
            {
                GameObject panel = new GameObject();
                Image image = panel.AddComponent<Image>();
                image.color = new Color(0.0f, 0.0f, 0.0f, 0.5f);

                panel.transform.SetParent(transform);
                panel.transform.SetAsFirstSibling();

                RectTransform rect = panel.GetComponent<RectTransform>();
                rect.anchorMin = new Vector2(0.0f, 0.0f);
                rect.anchorMax = new Vector2(1.0f, 1.0f);
                rect.pivot = new Vector2(0.5f, 0.5f);
                rect.offsetMin = Vector2.zero;
                rect.offsetMax = Vector2.zero;
                rect.sizeDelta = Vector2.zero;

                EventTrigger eventTrigger = panel.AddComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerDown;
                entry.callback.AddListener(data => Hide());
                eventTrigger.triggers.Add(entry);
            }
        }

        protected virtual void Start()
        {
            inputModule = CustomInputModule.main;
        }

        protected virtual void Update()
        {
            if (inputActionEnalbed)
                InputAction();
        }
    }
}