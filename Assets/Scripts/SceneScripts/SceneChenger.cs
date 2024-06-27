using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChenger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private int spawnPointNummer;
    [SerializeField] private GameObject spawnPointNewNummer;


    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            spawnPointNewNummer.GetComponent<NextSpawnPointNummer>().SetSpawnPointNummer(spawnPointNummer);
            LoadScene();
        }
    }
}
