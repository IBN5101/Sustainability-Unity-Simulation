using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Item[] items;
    [SerializeField] private Item currentItem;

    [Header("Main menu")]
    [SerializeField] private GameObject mainMenuScene;

    [Header("Item scene")]
    [SerializeField] private GameObject itemScene;
    [SerializeField] private TextMeshProUGUI item_name;
    [SerializeField] private RawImage item_display;
    [SerializeField] private TextMeshProUGUI item_price;
    [SerializeField] private TextMeshProUGUI item_sus;
    [SerializeField] private TextMeshProUGUI item_rating;

    [Header("Map scene")]
    [SerializeField] private GameObject mapScene;

    private void Start()
    {
        // Test
        GenerateItems();
    }

    public void SelectRandom()
    {
        // Set current item
        currentItem = items[Random.Range(0, items.Length)];

        // Set name
        item_name.SetText(currentItem.item_name);
        // Set image
        if (currentItem.item_image)
            item_display.texture = currentItem.item_image;
        // Set price
        item_price.SetText(currentItem.item_price.ToString("F"));
        // Set sus
        item_sus.SetText(currentItem.item_sus.ToString());
        // Set rating
        item_rating.SetText(currentItem.item_rating.ToString("F"));
    }

    public void GenerateItems()
    {
        foreach (Item i in items)
        {
            // Generate: price
            // Default: 0.1 - 1000.0
            if (i.item_price == 0)
                i.item_price = Random.Range(0.1f, 1000f);
            // Generate: sus
            // Default: 1 - 10
            if (i.item_sus == 0)
                i.item_sus = Random.Range(1, 11);
            // Generate: rating
            // Default: 1.0 - 5.0
            if (i.item_rating == 0)
                i.item_rating = Random.Range(0.1f, 5f);
        }
    }

}
