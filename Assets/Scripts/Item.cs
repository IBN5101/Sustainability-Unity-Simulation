using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item attributes")]
    [SerializeField] public string item_name;
    [SerializeField] public Texture item_image;
    [SerializeField] public float item_price;
    [SerializeField] public int item_sus;
    [SerializeField] public float item_rating;

    [Header("Map")]
    [SerializeField] public GameObject map_location;


    #region Map
    public void ShowLocation()
    {
        if (map_location)
            map_location.SetActive(true);
    }

    public void HideLocation()
    {
        if (map_location)
            map_location.SetActive(false);
    }
    #endregion
}
