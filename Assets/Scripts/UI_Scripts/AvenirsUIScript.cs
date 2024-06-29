using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvenirsUIScript : MonoBehaviour
{
    [SerializeField] private GameObject F_Button;

    private void OnEnable()
    {
        SilverChest.OpenF_Button += F_ButtonState;
        SceneChenger.OpenF_Button += F_ButtonState;
        Campfire.OpenF_Button += F_ButtonState;
        MarketScript.OpenF_Button += F_ButtonState;
        BlacksmithScript.OpenF_Button += F_ButtonState;
    }
    private void OnDisable()
    {
        SilverChest.OpenF_Button -= F_ButtonState;
        SceneChenger.OpenF_Button -= F_ButtonState;
        Campfire.OpenF_Button -= F_ButtonState;
        MarketScript.OpenF_Button -= F_ButtonState;
        BlacksmithScript.OpenF_Button -= F_ButtonState;
    }

    private void F_ButtonState() 
    {
        if (F_Button.activeSelf)
        {
            F_Button.SetActive(false);
        }
        else
        {
            F_Button.SetActive(true);
        }
    }
}
