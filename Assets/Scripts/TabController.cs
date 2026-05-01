using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for 'Image' Components

public class TabController : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] pages;

    // Start is called before the first frame update
    void Start()
    {
        ActivateTab(0);

    }

    public void ActivateTab(int tabNo)
    {
        // Loop through all pages to reset them
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(true);
            tabImages[i].color = Color.grey;
            MonoBehaviour.print("kvkub");
        }

        //Activate the specific tab and its image
        pages[tabNo].SetActive(true);
        tabImages[tabNo].color = Color.white;
    }
}
