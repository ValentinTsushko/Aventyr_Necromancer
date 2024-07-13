using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemProperties : MonoBehaviour
{
    public int Cost;
    public int Damage;
    public int PowerOfMagick;

    [SerializeField] private Sprite sprite;

    public Sprite GetSprite()
    {
        return sprite;
    }
}
