using UnityEngine;
using UnityEngine.UI; // Required for Image component

public class SelectionManager : MonoBehaviour
{
    public Image displayImage; // Drag your 'SelectedImage' here in the Inspector

    void Start()
    {
        // Hide the image at the start if nothing is selected
        displayImage.gameObject.SetActive(false);
    }

    public void SelectItem(Sprite newSprite)
    {
        // Turn the image on if it was hidden
        displayImage.gameObject.SetActive(true);

        // Change the sprite to the one passed in
        displayImage.sprite = newSprite;
    }
}
