using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Try to open location: " + sceneName);
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            LoadScene();
        }
    }
}
