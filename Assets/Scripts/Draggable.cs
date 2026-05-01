using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{   
    public CornerSlotManager cornerSlotManager;

    private Canvas canvas;
    private Image dragImage; // The clone we drag
    private RectTransform dragRect;
    
    private Vector2 startPosition;

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Create a clone image
        dragImage = new GameObject("DragImage").AddComponent<Image>();
        dragImage.sprite = GetComponent<Image>().sprite;
        dragImage.raycastTarget = false; // So it doesn't block UI
        dragImage.transform.SetParent(canvas.transform, false);

        dragRect = dragImage.GetComponent<RectTransform>();
        dragRect.sizeDelta = GetComponent<RectTransform>().sizeDelta;

        // Position it at the mouse
        dragRect.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragRect != null)
            dragRect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Check overlap with corner slot
        RectTransform slotRect = cornerSlotManager.cornerSlot.rectTransform;

        if (RectTransformUtility.RectangleContainsScreenPoint(slotRect, Input.mousePosition))
        {
            cornerSlotManager.TryMerge(GetComponent<Image>().sprite);
        }

        // Destroy the clone
        if (dragImage != null)
            GameObject.Destroy(dragImage.gameObject);
    }
}
