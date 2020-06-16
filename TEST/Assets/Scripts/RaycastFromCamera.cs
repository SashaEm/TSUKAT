using UnityEngine;

public class RaycastFromCamera : MonoBehaviour
{
    [SerializeField] private Camera camera;
    

    private void OnValidate()
    {
        if (camera == null)
            camera = Camera.main;
    }

    void Update()
    {
        Vector2 mouseScreenPosition = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(mouseScreenPosition);

        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            if (Input.GetMouseButton(0))
            {
                
            }
            
        }
    }
}
