using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    private bool IsEmpty = true;

    public bool GetIsEmpty()
    { 
        return IsEmpty; 
    }
    public void SetIsEmpty(bool newValue)
    {
        IsEmpty = newValue;
    }

}
