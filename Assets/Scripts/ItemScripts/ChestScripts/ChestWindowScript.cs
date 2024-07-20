using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestWindowScript : MonoBehaviour
{
    [SerializeField] private GameObject YesNoWindowPanel;
    [SerializeField] private Image ImgObj;
    [SerializeField] private TextMeshProUGUI ItemName;
    [SerializeField] private TextMeshProUGUI ItemCost;

    private GameObject NewItem;
    private HeroesInventory inventory = new HeroesInventory();
    private GameObject uiElement;

    public void SetNewItem(GameObject Item) 
    {
        NewItem = Item;
        ItemName.text = Item.GetComponent<ItemProperties>().ItemName;
        ItemCost.text = "Cost:  " + Item.GetComponent<ItemProperties>().Cost.ToString();
    }
    public void SetMainHero(Collider Hero)
    {
        //Hero.GetComponent<HeroesInventory>().GetNewItem(NewItem);

        inventory = Hero.GetComponent<HeroesInventory>();
    }

    public void YesButton()
    {
        inventory.GetNewItem(NewItem);
        Destroy(uiElement);
    }
    public void NoButton()
    {
        Destroy(uiElement);
    }
    public GameObject GetYesNoWindowPanel()
    {
        return YesNoWindowPanel;
    }
    public void SetUiElement(GameObject uiElement)
    {
        this.uiElement = uiElement;
    }
    public void SetItemImage()
    {
        ImgObj.sprite = NewItem.GetComponent<ItemProperties>().GetSprite();
    }
}
