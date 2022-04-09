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
    [SerializeField] private TextMeshProUGUI current_item_name;
    [SerializeField] private RawImage current_item_display;
    [SerializeField] private TextMeshProUGUI current_item_price;
    [SerializeField] private TextMeshProUGUI current_item_sus;
    [SerializeField] private TextMeshProUGUI current_item_rating;

    [Header("Map scene")]
    [SerializeField] private GameObject mapScene;
    [SerializeField] private GameObject mapItemScene;

    #region Initialize
    private void Start()
    {
        GenerateItems();
        ShowMainMenu();
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
    #endregion

    #region Display
    public void ShowMainMenu()
    {
        HideAllScenes();
        mainMenuScene.SetActive(true);
    }

    public void ShowItemScene()
    {
        HideAllScenes();
        itemScene.SetActive(true);

        DisplayCurrentItem();
    }

    public void ShowMapScene()
    {
        HideAllScenes();
        mapScene.SetActive(true);
    }

    public void ShowMapItemScene()
    {
        HideAllScenes();
        mapItemScene.SetActive(true);

        HideAllMapItemLocations();
        ShowCurrentItemLocation();
    }

    public void HideAllScenes()
    {
        mainMenuScene.SetActive(false);
        itemScene.SetActive(false);
        mapScene.SetActive(false);
        mapItemScene.SetActive(false);
    }
    #endregion

    #region Item
    public void SelectRandom()
    {
        // Set current item to be a random item
        currentItem = items[Random.Range(0, items.Length)];
    }

    public void DisplayCurrentItem()
    {
        // Set name
        current_item_name.SetText(currentItem.item_name);
        // Set image
        if (currentItem.item_image)
            current_item_display.texture = currentItem.item_image;
        // Set price
        current_item_price.SetText(currentItem.item_price.ToString("F"));
        // Set sus
        current_item_sus.SetText(currentItem.item_sus.ToString());
        // Set rating
        current_item_rating.SetText(currentItem.item_rating.ToString("F"));
    }

    public void ShowCurrentItemLocation()
    {
        currentItem.ShowLocation();
    }

    public void HideAllMapItemLocations()
    {
        foreach (Item i in items)
            i.HideLocation();
    }
    #endregion

    #region Debug
    public void DebugToConsole()
    {
        Debug.Log("!!!");
    }
    #endregion
}
