using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverChest : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("IsOpened", true);
        }
    }
}
