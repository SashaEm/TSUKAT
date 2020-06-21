using UnityEngine;
public class SphereInstance : MonoBehaviour
{
    public void Initialize()
    {
        // making smaller spheres
        transform.localScale *= 0.25f;
    }

}
