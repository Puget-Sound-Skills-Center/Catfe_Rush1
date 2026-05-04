using UnityEngine;
using UnityEngine.UI;

public class CoffeeTimer : MonoBehaviour
{
    public Image fillImage;        // Drag your Timer Image here
    public float brewTime = 25.0f;  // Total time in seconds
    private float currentTime;
    private bool isBrewing = false;

    void Start()
    {
        currentTime = brewTime;
        fillImage.fillAmount = 1; // Start full or empty based on preference
    }

    void Update()
    {
        if (isBrewing && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            fillImage.fillAmount = currentTime / brewTime; // Updates the visual circle

            if (currentTime <= 0)
            {
                OnBrewFinished();
            }
        }
    }

    public void StartBrewing() => isBrewing = true;

    void OnBrewFinished()
    {
        isBrewing = false;
        Debug.Log("Coffee is ready!");
        // Trigger your "done" animation or sound here
    }
}

