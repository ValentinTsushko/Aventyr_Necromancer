using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    [SerializeField] private GameObject InventoryPref;

    private string canvasName = "Avenirs_UI";
    private GameObject canvas;
    private GameObject uiElement;
    private bool IsOpened = false;

    void Start()
    {
        // Найти канвас на сцене по имени
        canvas = GameObject.Find(canvasName);
    }

    void Update()
    {
        if (canvas != null && Input.GetKeyDown(KeyCode.I) && !IsOpened)
        {
            OpenInventory();
        }
        else if(canvas != null && Input.GetKeyDown(KeyCode.I) && IsOpened)
        {
            CloseInventory();
        }
        else if (canvas == null && Input.GetKeyDown(KeyCode.I))
        {
            Debug.LogError("Canvas с указанным именем не найден на сцене.");
        }
    }
    private void OpenInventory()
    {
         // Инстанцировать префаб и установить его родителем канвас
         uiElement = Instantiate(InventoryPref.GetComponent<InventoryPanelScript>().GetInventoryPanel(), canvas.transform);

          // Опционально: установить позицию и другие свойства RectTransform
          RectTransform rectTransform = uiElement.GetComponent<RectTransform>();
          rectTransform.anchoredPosition = Vector2.zero;
          rectTransform.localScale = Vector3.one;
          rectTransform.sizeDelta = new Vector2(5, 5);  // Установить размер (по желанию)
          IsOpened = true;
        
    }
    private void CloseInventory()
    {
        IsOpened = false;
        Destroy(uiElement);
        uiElement = null;
    }
}
