using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class InventoryPanelScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> Slots;
    [SerializeField] private Transform inventoryPanel;

    public void AddItem(GameObject NewItem) 
    {
        Debug.Log("InventoryPanelScript");
        int i = 0;
        while (!Slots[i].GetComponent<SlotScript>().GetIsEmpty()) 
        {
            Debug.Log(i);
            i++;
        }

        GameObject slotObject = Slots[i].gameObject;
        Debug.Log("AddComponent<ItemProperties>()");
        slotObject.AddComponent<ItemProperties>();
        Debug.Log("AddComponent<ItemProperties>() added");
        slotObject.GetComponent<SlotScript>().SetIsEmpty(false);

        System.Type type = NewItem.GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (FieldInfo field in fields)
        {
            field.SetValue(slotObject.GetComponent<ItemProperties>(), field.GetValue(NewItem));
        }
    }
}
