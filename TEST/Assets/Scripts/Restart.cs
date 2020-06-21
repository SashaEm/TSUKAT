using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
