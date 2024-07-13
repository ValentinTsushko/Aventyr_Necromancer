using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    [SerializeField] private bool IsEmpty = true;
    [SerializeField] private Image ImgObj;

    private void Start()
    {
        IsEmpty = true;
    }

    public bool GetIsEmpty()
    {
        Debug.Log("SlotScript");
        return IsEmpty; 
    }
    public void SetIsEmpty(bool newValue)
    {
        IsEmpty = newValue;
    }
    public void SlotImageChenge(Sprite sprite)
    {
        Debug.Log("sprite     " + sprite == null);
        Debug.Log("ImgObj.sprite   " + ImgObj.sprite == null);
        ImgObj.sprite = sprite;
        Debug.Log("ImgObj.sprite    " + ImgObj.sprite == null);
    }
}
