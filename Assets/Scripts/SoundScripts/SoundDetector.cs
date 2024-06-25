using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDetector : MonoBehaviour
{
    [SerializeField] private Collider Detector;

    private void OnTriggerEnter(Collider other)
    {
        //SoundController SC = other.gameObject.GetComponentInParent<SoundController>;
        other.gameObject.GetComponent<SoundController>().StepsSound();
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
