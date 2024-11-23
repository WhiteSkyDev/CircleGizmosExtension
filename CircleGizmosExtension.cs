using System.Collections.Generic;
using UnityEngine;

public class CircleGizmosExtension : MonoBehaviour
{
    public static void DrawWireCircle(Vector3 center, Vector3 forward, Vector3 right, float radius, int divide = 16)
    {
        radius = Mathf.Abs(radius);
        forward = forward.normalized;
        right = right.normalized;
        divide = Mathf.Abs(divide);

        if (radius == 0 || divide < 3 || Vector3.Dot(forward, right) > 0.0001f) return;
        if (divide > 32) divide = 32;

        List<Vector3> vertices = new();
        Vector3 startPos = center + forward * radius;

        vertices.Add(startPos);

        float stepAngle = 360.0f / divide;
        float angle = 0f;

        while (angle < 360)
        {
            angle += stepAngle;

            if (angle <= 360)
            {
                float x = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
                float y = radius * Mathf.Sin(Mathf.Deg2Rad * angle);

                Vector3 vertex = center + right * y + forward * x;
                vertices.Add(vertex);
            }
            else
            {
                vertices.Add(startPos);
            }
        }

        for (int i = 1; i < vertices.Count; i++)
        {
            Gizmos.DrawLine(vertices[i - 1], vertices[i]);
        }
    }
}
