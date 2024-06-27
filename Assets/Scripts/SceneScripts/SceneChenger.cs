using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Название сцены, в которую вы хотите перейти
    [SerializeField] private string sceneName;

    // Метод, который вызывается для перехода в другую сцену
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    // Пример использования триггера для автоматического перехода
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Try to open location: " + sceneName);
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            LoadScene();
        }
    }
}
