using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> Slots;
    [SerializeField] private GameObject inventoryPanel;

    public void AddItem(GameObject NewItem) 
    {
        Debug.Log("NewItem.GetComponent<ItemProperties>()._sprite     " + NewItem.GetComponent<ItemProperties>().GetSprite());
        Debug.Log("InventoryPanelScript");
        int i = 0;
        while (!Slots[i].GetComponent<SlotScript>().GetIsEmpty()) 
        {
            Debug.Log(i);
            i++;
        }
        Debug.Log("Slots[i].name" + Slots[i].name); 
        GameObject slotObject = Slots[i].gameObject;

        Slots[i].gameObject.AddComponent<ItemProperties>();
        Slots[i].gameObject.GetComponent<SlotScript>().SetIsEmpty(false);

        Slots[i].gameObject.GetComponent<SlotScript>().SlotImageChenge(NewItem.GetComponent<ItemProperties>().GetSprite());

        //System.Type sourceType = NewItem.GetType();
        //FieldInfo[] fields = sourceType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        //Debug.Log("field.GetValue(NewItem)");
        //foreach (FieldInfo field in fields)
        //{
        //    Debug.Log("field.GetValue(NewItem)" + field.GetValue(NewItem));
        //    field.SetValue(slotObject.GetComponent<ItemProperties>(), field.GetValue(NewItem));
        //}
    }
    public GameObject GetInventoryPanel()
    {
        return inventoryPanel;
    }
}
