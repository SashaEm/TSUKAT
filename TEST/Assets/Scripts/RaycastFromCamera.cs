using UnityEngine;

public class RaycastFromCamera : MonoBehaviour
{
    [SerializeField] private Camera camera;

    private void OnValidate()
    {
        if (camera == null)
            camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseScreenPosition = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(mouseScreenPosition);

        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            if (Input.GetMouseButton(0))
            {
                raycastHit.collider.GetComponent<Renderer>().material.color = Color.green;
            }
            
        }
    }
}
