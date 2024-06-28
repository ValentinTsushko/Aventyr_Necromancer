using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverChest : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject NewItem;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("RTRT");
            animator.SetBool("IsOpened", true);
            Debug.Log("RTRT" + other.GetComponent<HeroesInventory>());
            other.GetComponent<HeroesInventory>().GetNewItem(NewItem);
        }
    }
}
