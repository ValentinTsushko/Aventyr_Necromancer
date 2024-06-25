using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private List<AudioClip> stepsSound;
    [SerializeField] private AudioSource footStepsAudio;
    [SerializeField] private float SoundSpeedWalk;

    private bool isCanStepSound = true;
    private float timer = 0f;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isCanStepSound = true;
                timer = 0;
            }
        }
    }

    public void StepsSound()
    {
        if (isCanStepSound)
        {
            timer = SoundSpeedWalk;
            footStepsAudio.clip = stepsSound[Random.Range(0, stepsSound.Count)];
            footStepsAudio.Play();
            isCanStepSound = false;
        }
    }
}
