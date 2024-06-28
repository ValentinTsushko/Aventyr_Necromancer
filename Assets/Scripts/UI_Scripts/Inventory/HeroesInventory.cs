using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesInventory : MonoBehaviour
{
    [SerializeField] private GameObject InventoryPrefab;

    public void GetNewItem(GameObject NewItem)
    {
        InventoryPrefab.GetComponent<InventoryPanelScript>().AddItem(NewItem);
    }
}
