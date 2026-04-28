using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab; // Drag your NPC prefab here
    public float spawnInterval = 60f; // Seconds between spawns
    public Vector3 spawnRange = new Vector3(10, 0, 10); // Area size

    void Start()
    {
        // Start the spawning loop
        InvokeRepeating("SpawnNPC", 0f, spawnInterval);
    }

    void SpawnNPC()
    {
        // Generate a random position
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnRange.x, spawnRange.x),
            -150, // Keep Y at 0 unless you want them in the air
            Random.Range(-spawnRange.z, spawnRange.z)
        );

        // Add the spawner's current position to the random offset
        Vector3 finalPos = transform.position + randomPos;

        // Create the NPC
        Instantiate(npcPrefab, finalPos, Quaternion.identity);
    }
}

