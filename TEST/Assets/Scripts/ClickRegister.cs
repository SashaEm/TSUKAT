using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRegister : MonoBehaviour
{
    [SerializeField] private Material red;
    [SerializeField] private Material yellow;
    [SerializeField] private Material black;

    public void ChangeColor()
    {
        switch (renderer.material)
        {
            case renderer.material == red:
                renderer.material = yellow;
            case renderer.material == yellow:
                Destroy(gameObject);
            case renderer.material == black:
                //TODO: Lose();

            default:
                break;
        }
    }
}
