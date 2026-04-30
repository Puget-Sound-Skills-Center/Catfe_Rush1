using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CraftingManager : MonoBehaviour
{
    public Image slot1; // Assign the UI Image in the corner
    public Image slot2; // Assign a second UI Image in the corner
    public Sprite resultSprite; // The image they turn into

    private Image activeDraggingImage;
    private bool isSlot1Filled = false;
    private bool isSlot2Filled = false;

    // Call this from your buttons in the inspector (OnClick)
    public void SelectItem(Button clickedButton)
    {
        Sprite selectedSprite = clickedButton.image.sprite;

        if (!isSlot1Filled)
        {
            slot1.sprite = selectedSprite;
            slot1.gameObject.SetActive(true);
            isSlot1Filled = true;
        }
        else if (!isSlot2Filled)
        {
            slot2.sprite = selectedSprite;
            slot2.gameObject.SetActive(true);
            isSlot2Filled = true;

            // Add a drag component to the second slot dynamically
            AddDragLogic(slot2);
        }
    }

    void AddDragLogic(Image img)
    {
        EventTrigger trigger = img.gameObject.AddComponent<EventTrigger>();

        // Create the drag entry
        EventTrigger.Entry dragEntry = new EventTrigger.Entry();
        dragEntry.eventID = EventTriggerType.Drag;
        dragEntry.callback.AddListener((data) => { OnDrag((PointerEventData)data, img); });
        trigger.triggers.Add(dragEntry);

        // Create the drop entry (when let go)
        EventTrigger.Entry dropEntry = new EventTrigger.Entry();
        dropEntry.eventID = EventTriggerType.PointerUp;
        dropEntry.callback.AddListener((data) => { CheckCollision(); });
        trigger.triggers.Add(dropEntry);
    }

    void OnDrag(PointerEventData data, Image img)
    {
        img.transform.position = data.position;
    }

    void CheckCollision()
    {
        // Check distance between slot 1 and slot 2
        float dist = Vector3.Distance(slot1.transform.position, slot2.transform.position);

        if (dist < 50f) // If they are close enough
        {
            MergeItems();
        }
    }

    void MergeItems()
    {
        slot1.sprite = resultSprite;
        slot2.gameObject.SetActive(false); // Hide the second one
        slot1.transform.position = slot1.transform.position; // Reset position if needed
        Debug.Log("Items Merged!");
    }
}
