using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public Color lineColor = Color.yellow;

    void OnDrawGizmos()
    {
        Gizmos.color = lineColor;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Vector3 start = transform.GetChild(i).position;
            Vector3 end = transform.GetChild(i + 1).position;
            Gizmos.DrawLine(start, end);
        }
    }
}
