using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float gravity;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float jumpDuration;

    private bool isGrounded;

    private void Update()
    {
        Gravity();

        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void Gravity()
    {
        var position = transform.position;
        var gravityOffset = new Vector2(position.x, position.y - gravity);

        if (!isGrounded)
        {
            transform.position = Vector3.Lerp(position, gravityOffset, Time.deltaTime);
        }
    }

    private void Jump()
    {        
        var position = transform.position;
        var jumpOffset = new Vector2(position.x, position.y + jumpSpeed);

        if (isGrounded)
        {
            StartCoroutine(Jumping(position, jumpOffset, jumpDuration));
        }
    }

    private IEnumerator Jumping(Vector2 start, Vector2 offset, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(start, offset, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = offset;
    }

    public void IsGrounded() => isGrounded = true;
    public void IsNotGrounded() => isGrounded = false;
}
