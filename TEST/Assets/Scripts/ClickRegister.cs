using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickRegister : MonoBehaviour
{
    
    [SerializeField] private Material red;
    [SerializeField] private Material green;
    [SerializeField] private Material black;

    private GameObject ScoreManagerInstance;
    private ScoreManager ScoreManager;

    private bool isClicked = false;
    [HideInInspector] public static bool isLost = false;

    private Renderer rend;
    private void Awake()
    {
        ScoreManagerInstance = GameObject.Find("ScoreManager");
        ScoreManager = ScoreManagerInstance.GetComponent<ScoreManager>();
    }
    public void ChangeColor()
    {
        if (rend == null)
            rend = GetComponent<Renderer>();

        var material = rend.sharedMaterial;
        if (material == red)
        {
            rend.sharedMaterial = green;
        }
        else if (material == green)
        {
            isClicked = true;
            Destroy(gameObject);
        }
        else if (material == black)
        {
            isLost = true;
            Time.timeScale = 0f;
        }
    }

    private void OnDestroy()
    {
        if (rend == null)
            rend = GetComponent<Renderer>();
        var material = rend.sharedMaterial;
        if (!isClicked)
        {
            if (material == red)
            {
                ScoreManager.redMissCount += 1;
                ScoreManager.ChangeScore();
            }
            else if (material == green)
            {
                ScoreManager.greenMissCount += 1;
                ScoreManager.ChangeScore();
            }
        }
    }
}
