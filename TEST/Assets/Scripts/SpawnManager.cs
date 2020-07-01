using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform cornerTopLeft;
    [SerializeField] private Transform cornerTopRight;
    [SerializeField] private Transform cornerBottomLeft;
    [SerializeField] private Transform cornerBottomRight;

    [SerializeField] private Spawner spawner;

    [SerializeField] private float scaling = 1;
      // тут щось загадкове і не зовсім зрозуміле. Ну, я розумію, що ти так пробуєш обмежити області появи кульок, але якось це не дуже красиво
    private Vector3 BottomLeft => cornerBottomLeft.position;
    private Vector3 BottomRight => cornerBottomLeft.position + Vector3.right * Vector3.Distance(cornerBottomLeft.position, cornerBottomRight.position) * scaling;
    private Vector3 TopLeft => cornerBottomLeft.position + Vector3.up * Vector3.Distance(cornerBottomLeft.position, cornerTopLeft.position) * scaling;
    private Vector3 TopRight => new Vector3(BottomRight.x, TopLeft.y, cornerTopRight.position.z);

    

    public void SpawnAtRandomPosInsideRect()
    { 
         var randX = Random.Range(0f, 1f);
         var randY = Random.Range(0f, 1f);

         var bottomX = Vector3.Lerp(BottomLeft,BottomRight, randX);     // find randX between bottom points
         var topX = Vector3.Lerp(TopLeft, TopRight, randX);                        // find randX between top points (same as over)

         var targetPos = Vector3.Lerp(bottomX, topX, randY);                    // use bottomX and topX together with randY to find the relative ypos
         spawner.SpawnObstacle(targetPos);
    }
    // No intellisense :(
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var pointSize = 0.025f;

        var bl =BottomLeft;
        var tl = TopLeft;
        var br = BottomRight;
        var tr = TopRight;

        // Draw points directly from data
        Gizmos.DrawSphere(tl, pointSize);
        Gizmos.DrawSphere(tr, pointSize);
        Gizmos.DrawSphere(br, pointSize);
        Gizmos.DrawSphere(bl, pointSize);

        // Draw lines between points
        Gizmos.DrawLine(tl, tr);
        Gizmos.DrawLine(tr, br);
        Gizmos.DrawLine(br, bl);
        Gizmos.DrawLine(bl, tl);
    }
}
