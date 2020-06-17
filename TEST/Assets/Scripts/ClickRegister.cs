using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRegister : MonoBehaviour
{

    [SerializeField] private Material red;
    [SerializeField] private Material green;
    [SerializeField] private Material black;

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
            Destroy(gameObject);
        }else if (material == black)
        {
            Debug.Log("Lose");
        }
    }
}
