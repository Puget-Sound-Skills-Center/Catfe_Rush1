using UnityEngine;
using UnityEngine.UI;

public class ClothingSlotManager : MonoBehaviour
{
    public Image craftcollider;
    public Sprite mergedResult;

    private bool hasItem = false;

    public void SetCraftCollider(Sprite sprite)
    {
        craftcollider.sprite = sprite;
        craftcollider.gameObject.SetActive(true);
        hasItem = true;
    }

    public void TryMerge(Sprite draggedSprite)
    {
        if (!hasItem) return;

        // Later you can add recipe logic here
        craftcollider.sprite = mergedResult;
        Debug.Log("Merged!");

    }
}