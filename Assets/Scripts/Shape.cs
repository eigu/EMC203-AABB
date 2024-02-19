using UnityEngine;

[System.Serializable]
public class Shape : MonoBehaviour
{
    public Vector2 originPoint
    {
        get { return transform.position; }
    }

    public virtual void DrawCollider()
    {

    }
}
