using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverChest : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.CompareTag("Player"));
        Debug.Log(Input.GetKeyDown(KeyCode.F));
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("RTRT");
            animator.SetBool("IsOpened", true);
        }
    }
}
