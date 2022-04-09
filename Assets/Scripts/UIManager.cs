using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class UIManager : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Item[] items;
    [SerializeField] private Item currentItem;
    [SerializeField] private Item rec1;
    [SerializeField] private Item rec2;
    private Stack<Item> itemHistory;

    [Header("Main menu")]
    [SerializeField] private GameObject mainMenuScene;
    // Popup panels
    [SerializeField] private GameObject panelFAQ;
    [SerializeField] private GameObject panelBug;

    [Header("Item scene")]
    [SerializeField] private GameObject itemScene;
    [SerializeField] private TextMeshProUGUI current_item_name;
    [SerializeField] private RawImage current_item_display;
    [SerializeField] private TextMeshProUGUI current_item_price;
    [SerializeField] private TextMeshProUGUI current_item_sus;
    [SerializeField] private TextMeshProUGUI current_item_rating;
    // Popup panels
    [SerializeField] private GameObject panelSus;
    [SerializeField] private TextMeshProUGUI panelSusRating;
    [SerializeField] private GameObject panelIngredients;
    [SerializeField] private GameObject panelRating;
    
    [Header("Recommendations")]
    // Ducking end me
    // Rec-1
    [SerializeField] private TextMeshProUGUI rec1_item_name;
    [SerializeField] private RawImage rec1_item_display;
    [SerializeField] private TextMeshProUGUI rec1_item_price;
    [SerializeField] private TextMeshProUGUI rec1_item_sus;
    [SerializeField] private TextMeshProUGUI rec1_item_rating;
    // Rec-2
    [SerializeField] private TextMeshProUGUI rec2_item_name;
    [SerializeField] private RawImage rec2_item_display;
    [SerializeField] private TextMeshProUGUI rec2_item_price;
    [SerializeField] private TextMeshProUGUI rec2_item_sus;
    [SerializeField] private TextMeshProUGUI rec2_item_rating;

    [Header("Map scene")]
    [SerializeField] private GameObject mapScene;
    [SerializeField] private GameObject mapItemScene;

    #region Initialize
    private void Start()
    {
        // Initialize history
        itemHistory = new Stack<Item>();

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
    // Main menu
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
        // Scenes
        mainMenuScene.SetActive(false);
        itemScene.SetActive(false);
        mapScene.SetActive(false);
        mapItemScene.SetActive(false);

        // Popup panels (just in case)
        panelFAQ.SetActive(false);
        panelBug.SetActive(false);
        panelSus.SetActive(false);
        panelIngredients.SetActive(false);
        panelRating.SetActive(false);
    }
    #endregion

    #region Item
    public void SelectRandom()
    {
        // Set current item to be a random item
        currentItem = items[Random.Range(0, items.Length)];

        // Set recommendation items
        List<Item> itemList = items.ToList();
        itemList.Remove(currentItem);
        // Ah yes, there is no get+remove in C#
        // I blame my Java experience
        for (int i = 0; i < 2; i++)
        {
            int index = Random.Range(0, itemList.Count);
            // Bad solution
            if (i == 0)
                rec1 = itemList[index];
            if (i == 1)
                rec2 = itemList[index];
            itemList.RemoveAt(index);
        }
    }

    public void SelectRandomWithoutMain()
    {
        // This method is the same as SelectRandom()
        // but without random on currentItem
        // Bad solution.

        // Set recommendation items
        List<Item> itemList = items.ToList();
        itemList.Remove(currentItem);
        // Ah yes, there is no get+remove in C#
        // I blame my Java experience
        for (int i = 0; i < 2; i++)
        {
            int index = Random.Range(0, itemList.Count);
            // Bad solution
            if (i == 0)
                rec1 = itemList[index];
            if (i == 1)
                rec2 = itemList[index];
            itemList.RemoveAt(index);
        }
    }

    public void DisplayCurrentItem()
    {
        // Main item
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

        // Set rating (for sus panel)
        panelSusRating.SetText(currentItem.item_sus.ToString());

        // Display recommendations
        // (bundled together with this method just in case)
        DisplayRecommendations();
    }

    public void DisplayRecommendations()
    {
        // Rec-1
        // Set name
        rec1_item_name.SetText(rec1.item_name);
        // Set image
        if (rec1.item_image)
            rec1_item_display.texture = rec1.item_image;
        // Set price
        rec1_item_price.SetText(rec1.item_price.ToString("F"));
        // Set sus
        rec1_item_sus.SetText(rec1.item_sus.ToString());
        // Set rating
        rec1_item_rating.SetText(rec1.item_rating.ToString("F"));

        // Rec-2
        // Set name
        rec2_item_name.SetText(rec2.item_name);
        // Set image
        if (rec2.item_image)
            rec2_item_display.texture = rec2.item_image;
        // Set price
        rec2_item_price.SetText(rec2.item_price.ToString("F"));
        // Set sus
        rec2_item_sus.SetText(rec2.item_sus.ToString());
        // Set rating
        rec2_item_rating.SetText(rec2.item_rating.ToString("F"));
    }

    // Item location
    public void ShowCurrentItemLocation()
    {
        currentItem.ShowLocation();
    }
    public void HideAllMapItemLocations()
    {
        foreach (Item i in items)
            i.HideLocation();
    }

    // Item recommendation navigation
    public void BackButton()
    {
        if (itemHistory.Count == 0)
            return;

        currentItem = itemHistory.Pop();
        SelectRandomWithoutMain();

        DisplayCurrentItem();
    }
    public void MoveToRec(int rec)
    {
        // Modify history
        itemHistory.Push(currentItem);

        // Generate new
        if (rec == 1)
            currentItem = rec1;
        if (rec == 2)
            currentItem = rec2;
        SelectRandomWithoutMain();
        DisplayCurrentItem();
    }
    #endregion

    #region Debug
    public void DebugToConsole()
    {
        Debug.Log("!!!");
    }
    #endregion
}
