using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    [SerializeField] private bool IsEmpty = true;

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

}
