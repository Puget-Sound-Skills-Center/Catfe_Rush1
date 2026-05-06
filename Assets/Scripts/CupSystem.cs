using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CupSystem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public CornerSlotManager cornerSlotManager;
    public CoffeeSlotManager coffeeSlotManager;

    private Canvas canvas;
    private Image dragImage;
    private RectTransform dragRect;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector2 startPosition;

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        startPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        dragImage = new GameObject("DragImage").AddComponent<Image>();
        dragImage.sprite = GetComponent<Image>().sprite;
        dragImage.raycastTarget = false;
        dragImage.transform.SetParent(canvas.transform, false);

        dragRect = dragImage.GetComponent<RectTransform>();
        dragRect.sizeDelta = rectTransform.sizeDelta;
        dragRect.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragRect != null)
            dragRect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        RectTransform slotRect = cornerSlotManager.cornerSlot.rectTransform;

        if (RectTransformUtility.RectangleContainsScreenPoint(slotRect, Input.mousePosition))
        {
            cornerSlotManager.TryMerge(GetComponent<Image>().sprite);
        }

        // Reset original item
        rectTransform.anchoredPosition = startPosition;
    }
}
