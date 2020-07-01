using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void RestartGame()
    {
        // Не варто зашивати жорстко назву сцени в код. Через місяць сцену переіменуєш і будеш шукати чого не працює.
        SceneManager.LoadScene("GameScene");
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
