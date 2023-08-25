using UnityEngine;
using UnityEngine.EventSystems;

namespace RPG.UI
{
    public class DraggablePanel : MonoBehaviour, IDragHandler
    {
        private RectTransform _rectTransform;
        private Vector2 _originalPosition;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _originalPosition = _rectTransform.position;
        }

        private void OnEnable()
        {
            _rectTransform.position = _originalPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta;
        }
    }
}