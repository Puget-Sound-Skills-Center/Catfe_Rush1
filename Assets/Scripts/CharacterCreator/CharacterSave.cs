using UnityEngine;
using System.IO;

[System.Serializable]
public class CharacterSaveData
{
    public int bodyID;
    public int shirtID;
    public int pantsID;
}

public class SaveSystem : MonoBehaviour
{
    public CharacterSaveData currentEquipment;
    private string savePath;

    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "character_save.json");
    }

    public void SaveCharacter()
    {
        string json = JsonUtility.ToJson(currentEquipment);
        File.WriteAllText(savePath, json);
    }

    public void LoadCharacter()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            currentEquipment = JsonUtility.FromJson<CharacterSaveData>(json);
            // Next: Use the IDs to re-assign sprites from your asset arrays
        }
    }
}

