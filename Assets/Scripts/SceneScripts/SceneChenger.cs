using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChenger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private int spawnPointNummer;
    [SerializeField] private GameObject spawnPointNewNummer;

    public static event System.Action OpenF_Button;

    private bool IsInTrigg = false;

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerTrigger") && !IsInTrigg)
        {
            OpenF_Button?.Invoke();
            IsInTrigg = true;
        }
        
        if (other.CompareTag("PlayerTrigger") && Input.GetKeyDown(KeyCode.F))
        {
            spawnPointNewNummer.GetComponent<NextSpawnPointNummer>().SetSpawnPointNummer(spawnPointNummer);
            LoadScene();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            OpenF_Button?.Invoke();
            IsInTrigg = false;
        }
    }
}
