using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverChest : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject NewItem;
    [SerializeField] private Collider ChestTrigger;
    [SerializeField] private GameObject ChestWindowPref;
    private GameObject canvas;
    private string canvasName = "Avenirs_UI";

    public static event System.Action OpenF_Button;


    void Start()
    {
        // Найти канвас на сцене по имени
        canvas = GameObject.Find(canvasName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            OpenF_Button?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            OpenF_Button?.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("SilverChest");

        if (other.CompareTag("PlayerTrigger") && Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("IsOpened", true);
            gameObject.SetActive(false);

            GetItemWindow(other);
            
        }
    }

    private void GetItemWindow(Collider other)
    {
        GameObject uiElement = Instantiate(ChestWindowPref.GetComponent<ChestWindowScript>().GetYesNoWindowPanel(), canvas.transform);
        RectTransform rectTransform = uiElement.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.localScale = Vector3.one;

        ChestWindowPref.GetComponent<ChestWindowScript>().SetNewItem(NewItem);
        ChestWindowPref.GetComponent<ChestWindowScript>().SetMainHero(other);
        ChestWindowPref.GetComponent<ChestWindowScript>().SetUiElement(uiElement);
        ChestWindowPref.GetComponent<ChestWindowScript>().SetItemImage();
    }
}
