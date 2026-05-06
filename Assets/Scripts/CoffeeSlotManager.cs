using UnityEngine;
using UnityEngine.UI;

public class CoffeeSlotManager : MonoBehaviour
{
    public Image cupSlot; // The big white rectangle
    public bool hasCup = false;

    public void PlaceCup(Sprite cupSprite)
    {
        cupSlot.sprite = cupSprite;
        cupSlot.gameObject.SetActive(true);
        hasCup = true;
    }

}