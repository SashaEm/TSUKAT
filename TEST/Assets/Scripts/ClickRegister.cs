using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickRegister : MonoBehaviour
{
    
    [SerializeField] private Material red;
    [SerializeField] private Material green;
    [SerializeField] private Material black;

    
     private bool isClicked = false;
    [HideInInspector] public static bool isLost = false;

    private Renderer rend;



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
                RaycastFromCamera.redMissCount += 1;
            }
            else if (material == green)
            {
                RaycastFromCamera.greenMissCount += 1;
            }
        }
    }
}
