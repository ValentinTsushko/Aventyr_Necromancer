using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

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

        slotObject.GetComponent<Image>().sprite = NewItem.GetComponent<ItemProperties>()._sprite;

        System.Type sourceType = NewItem.GetType();
        FieldInfo[] fields = sourceType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        Debug.Log("field.GetValue(NewItem)");
        foreach (FieldInfo field in fields)
        {
            Debug.Log("field.GetValue(NewItem)" + field.GetValue(NewItem));
            field.SetValue(slotObject.GetComponent<ItemProperties>(), field.GetValue(NewItem));
        }
    }
}
