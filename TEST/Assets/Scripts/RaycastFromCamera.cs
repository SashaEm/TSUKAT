using UnityEngine;

public class RaycastFromCamera : MonoBehaviour
{
    [SerializeField] private Camera cameraMain;

    private void OnValidate()
    {
        if (cameraMain == null)
            cameraMain = Camera.main;
    }

    void Update()
    {
        Vector2 mouseScreenPosition = Input.mousePosition;
        Ray ray = cameraMain.ScreenPointToRay(mouseScreenPosition);

        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                var clickRegister = raycastHit.transform.GetComponent<ClickRegister>();
                if (clickRegister != null)
                {
                    clickRegister.ChangeColor();
                }
            }
        }
    }
}
