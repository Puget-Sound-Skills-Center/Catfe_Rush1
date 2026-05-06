using UnityEngine;
using UnityEngine.UI;

public class CornerSlotManager : MonoBehaviour
{
    public Image cornerSlot;
    public Sprite mergedResult;

    private bool hasItem = false;

    public void SetCornerItem(Sprite sprite)
    {
        cornerSlot.sprite = sprite;
        cornerSlot.gameObject.SetActive(true);
        hasItem = true;
    }

    public void TryMerge(Sprite draggedSprite)
    {
        if (!hasItem) return;

        // Later you can add recipe logic here
        cornerSlot.sprite = mergedResult;
        Debug.Log("Merged!");

    }
}
