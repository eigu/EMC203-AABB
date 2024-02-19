using UnityEngine;
using UnityEngine.Events;

public class CollisionScript : MonoBehaviour
{
    private Shape playerCollider;

    public UnityEvent collidingWithNothing;
    public UnityEvent collidingWithGround;

    private void Awake()
    {
        playerCollider = GetComponent<Shape>();
    }

    private void Update()
    {
        HandleCollision();
    }

    public void HandleCollision()
    {
        var Colliders = FindObjectsOfType<Shape>();

        foreach (var c in Colliders)
        {
            if (playerCollider == c) continue;

            if (!CollisionLibrary.CheckCollision(playerCollider, c))
            {
                collidingWithNothing?.Invoke();
                return;
            }

            if (c.CompareTag("Ground")) collidingWithGround?.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        var Colliders = FindObjectsOfType<Shape>();

        foreach (var c in Colliders)
        {
            c.DrawCollider();
        }
    }
}
