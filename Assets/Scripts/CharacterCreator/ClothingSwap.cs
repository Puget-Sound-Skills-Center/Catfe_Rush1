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
    public Sprite[] Breed;
    public Sprite[] Shirt; 
    public Sprite[] pants; 
    public Sprite[] Aprons;
    public Sprite[] Accessory;

    private SaveData currentSelection = new SaveData();
    private string saveFilePath;

    void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "dressup_save.json");
        LoadProgress();
    }

    // Button Mechanics: Call these directly from your UI buttons
    // Call these from a "Next" button in Unity
    public void NextBreed()
    {
        currentSelection.breedIndex = (currentSelection.breedIndex + 1) % Breed.Length;
        UpdateVisuals();
    }

    public void NextShirt()
    {
        currentSelection.shirtIndex = (currentSelection.shirtIndex + 1) % Shirt.Length;
        UpdateVisuals();
    }

    public void NextPants()
    {
        currentSelection.pantsIndex = (currentSelection.pantsIndex + 1) % pants.Length;
        UpdateVisuals();
    }

    public void NextApron()
    {
        currentSelection.apronIndex = (currentSelection.apronIndex + 1) % Aprons.Length;
        UpdateVisuals();
    }

    public void NextAccessory()
    {
        currentSelection.accIndex = (currentSelection.accIndex + 1) % Accessory.Length;
        UpdateVisuals();
    }


    private void UpdateVisuals()
    {
        // Cycles through arrays based on current selection index
        breedRender.sprite = Breed[currentSelection.breedIndex];
        shirtRender.sprite = Shirt[currentSelection.shirtIndex];
        pantsRender.sprite = pants[currentSelection.pantsIndex];
        apronRender.sprite = Aprons[currentSelection.apronIndex];
        accRender.sprite = Accessory[currentSelection.accIndex];
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
