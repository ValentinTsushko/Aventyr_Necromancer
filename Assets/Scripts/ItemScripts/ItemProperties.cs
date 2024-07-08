using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemProperties : MonoBehaviour
{
    public int Cost;
    public int Damage;
    public int PowerOfMagick;

    private Sprite sprite;

    public Sprite _sprite
    {
        get { return sprite; }
    }
}
