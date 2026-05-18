using UnityEngine;
using System.IO;
using Unity.Android.Gradle;

public class ClothingSwap : MonoBehaviour
{
    [System.Serializable]
    public class SaveData
    {
        public int breedIndex;
        public int shirtIndex;
        public int pantsIndex;
        public int apronIndex;
        public int accIndex;
    }

    [Header("Sprite Renderers")]
    public SpriteRenderer breedRender;
    public SpriteRenderer shirtRender;
    public SpriteRenderer pantsRender;
    public SpriteRenderer apronRender;
    public SpriteRenderer accRender;

    [Header("Asset Arrays (Drop your images here)")]
    public Sprite[] catBreeds;
    public Sprite[] shirts;
    public Sprite[] pants;
    public Sprite[] aprons;
    public Sprite[] accessories;

    private SaveData currentSelection = new SaveData();
    private string saveFilePath;

    void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "dressup_save.json");
        LoadProgress();
    }

    // BUTTON MECHANICS: Call these directly from your UI buttons
    public void SelectBreed(int index) { currentSelection.breedIndex = index; UpdateVisuals(); }
    public void SelectShirt(int index) { currentSelection.shirtIndex = index; UpdateVisuals(); }
    public void SelectPants(int index) { currentSelection.pantsIndex = index; UpdateVisuals(); }
    public void SelectApron(int index) { currentSelection.apronIndex = index; UpdateVisuals(); }
    public void SelectAccessory(int index) { currentSelection.accIndex = index; UpdateVisuals(); }

    private void UpdateVisuals()
    {
        // Cycles through arrays based on current selection index
        breedRender.sprite = catBreeds[currentSelection.breedIndex];
        shirtRender.sprite = shirts[currentSelection.shirtIndex];
        pantsRender.sprite = pants[currentSelection.pantsIndex];
        apronRender.sprite = aprons[currentSelection.apronIndex];
        accRender.sprite = accessories[currentSelection.accIndex];
    }

    // Save/Load Mechanics: Keeps progress safe from file
    public void SaveProgress()
    {
        string json = JsonUtility.ToJson(currentSelection);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Character Saved!");
    }

    public void LoadProgress()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            currentSelection = JsonUtility.FromJson<SaveData>(json);
        }
        UpdateVisuals(); // Instantly visually builds the saved cat
    }
}
