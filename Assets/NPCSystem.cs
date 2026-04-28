using UnityEngine;
using TMPro; // Required for TextMeshPro
using System.Collections;

public class NPCController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject speechBubble;
    public TextMeshProUGUI dialogueText;

    [Header("Settings")]
    public string npcMessage = "Hello! Take this.";
    public float displayDuration = 2.0f;

    [Header("Item Drop")]
    public GameObject itemToDrop;
    public Transform dropPoint;

    private bool hasInteracted = false;
    private bool isPlayerInRange = false;

    void Update()
    {
        // If player is nearby and presses 'E' and we haven't talked yet
        if (isPlayerInRange && !hasInteracted && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ShowSpeechAndDropItem());
        }
    }

    IEnumerator ShowSpeechAndDropItem()
    {
        hasInteracted = true;

        // 1. Show the bubble
        speechBubble.SetActive(true);
        dialogueText.text = npcMessage;

        // 2. Wait for the duration
        yield return new WaitForSeconds(displayDuration);

        // 3. Hide the bubble
        speechBubble.SetActive(false);

        // 4. Spawn the item
        if (itemToDrop != null)
        {
            Instantiate(itemToDrop, dropPoint.position, Quaternion.identity);
        }
    }

    // Detection logic
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) isPlayerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) isPlayerInRange = false;
    }
}
