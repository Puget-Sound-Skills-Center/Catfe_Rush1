using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    public GameObject[] pages;  // Assign your page GameObjects here
    public Button[] tabButtons; // Assign your tab buttons here

    void Start()
    {
        // Show the first page by default
        OpenPage(0);
    }

    public void OpenPage(int index)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            // Toggle page visibility
            pages[i].SetActive(i == index);

            // Optional: Change button colors to highlight the active tab
            ColorBlock cb = tabButtons[i].colors;
            cb.normalColor = (i == index) ? Color.white : Color.gray;
            tabButtons[i].colors = cb;
        }
    }
}
    