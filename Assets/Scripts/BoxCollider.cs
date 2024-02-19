using UnityEngine;

public class BoxCollider : Shape
{
    private float width
    {
        get { return transform.localScale.x; }
    }
    private float length
    {
        get { return transform.localScale.y; }
    }

    public float xMin
    {
        get { return originPoint.x - (width * .5f);}
    }
    public float xMax
    {
        get { return originPoint.x + (width * .5f); }
    }
    public float yMin
    {
        get { return originPoint.y - (length * .5f); }
    }
    public float yMax
    {
        get { return originPoint.y + (length * .5f); }
    }

    public Vector2 point1 => new Vector3(xMin, yMin);
    public Vector2 point2 => new Vector3(xMin, yMax);
    public Vector2 point3 => new Vector3(xMax, yMax);
    public Vector2 point4 => new Vector3(xMax, yMin);
            
    public override void DrawCollider()
    {
        base.DrawCollider();

        var VectorArray = new Vector2[] { point1, point2, point3, point4 };

        for ( int i = 0; i < VectorArray.Length; i++)
        {
            var v = VectorArray[i];
            var v2 = VectorArray[(i + 1) % VectorArray.Length];
            Gizmos.DrawLine(v, v2);
        }
    }
}
