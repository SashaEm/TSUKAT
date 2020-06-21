using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastFromCamera : MonoBehaviour
{
    public GameObject panel;

    [SerializeField] private Camera cameraMain;
    [HideInInspector] public static int score = 0;
    [HideInInspector] public static int redMissCount = 0;
    [HideInInspector] public static int greenMissCount = 0;
    
    [SerializeField] private Text scoreText;
    [SerializeField] private Text redText;
    [SerializeField] private Text greenText;

    private void OnValidate()
    {
        if (cameraMain == null)
            cameraMain = Camera.main;
    }

    void Awake()
    {
        ClickRegister.isLost = false;
    }

    

    void Update()
    {
        Vector2 mouseScreenPosition = Input.mousePosition;
        Ray ray = cameraMain.ScreenPointToRay(mouseScreenPosition);

        if (ClickRegister.isLost)
        {
            panel.SetActive(true);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                var clickRegister = raycastHit.transform.GetComponent<ClickRegister>();
                if (clickRegister != null)
                {
                    clickRegister.ChangeColor();
                    if (clickRegister.CompareTag("GoodSphere"))
                    {
                        score += 1;
                    }
                }
            }
        }
        scoreText.text = $"score: {score.ToString()}";
        redText.text = $": {redMissCount.ToString()}";
        greenText.text = $": {greenMissCount.ToString()}";
    }
}
