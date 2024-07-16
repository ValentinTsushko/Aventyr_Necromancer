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
        // ����� ������ �� ����� �� �����
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
            Debug.LogError("Canvas � ��������� ������ �� ������ �� �����.");
        }
    }
    private void OpenInventory()
    {
         // �������������� ������ � ���������� ��� ��������� ������
         uiElement = Instantiate(InventoryPref.GetComponent<InventoryPanelScript>().GetInventoryPanel(), canvas.transform);

          // �����������: ���������� ������� � ������ �������� RectTransform
          RectTransform rectTransform = uiElement.GetComponent<RectTransform>();
          rectTransform.anchoredPosition = Vector2.zero;
          rectTransform.localScale = Vector3.one;
          rectTransform.sizeDelta = new Vector2(5, 5);  // ���������� ������ (�� �������)
          IsOpened = true;
        
    }
    private void CloseInventory()
    {
        IsOpened = false;
        Destroy(uiElement);
        uiElement = null;
    }
}
