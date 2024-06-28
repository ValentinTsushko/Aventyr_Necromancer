using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class InventoryPanelScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> Slots = new List<GameObject>();
    [SerializeField] private Transform inventoryPanel;

    void Start()
    {

    }

    public void AddItem(GameObject NewItem) 
    {
        int i = 0;
        while (!Slots[i].GetComponent<SlotScript>().GetIsEmpty()) 
        { 
            i++;
        }
        Component copy = Slots[i].AddComponent<ItemProperties>();
        System.Type type = NewItem.GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(NewItem));
        }
    }
}
