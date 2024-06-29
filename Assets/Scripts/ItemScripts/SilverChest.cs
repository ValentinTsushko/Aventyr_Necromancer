using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverChest : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject NewItem;
    [SerializeField] private Collider ChestTrigger;

    public static event System.Action OpenF_Button;

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
            GameObject currentObject = gameObject;
            currentObject.gameObject.SetActive(false);
            
            other.GetComponent<HeroesInventory>().GetNewItem(NewItem);
        }
    }
}
