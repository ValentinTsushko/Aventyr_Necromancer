using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDetector : MonoBehaviour
{
    [SerializeField] private Collider Detector;
    [SerializeField] private AudioSource AS;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SoundController>()) other.gameObject.GetComponent<SoundController>().StepsSound(AS);
        else ;
    }
}
