using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Camera cam;
    private Vector3 movement;
    void Update()
    {
        Vector2 move = new(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        Vector3 camForward = cam.transform.forward; camForward.y = 0f; camForward = camForward.normalized;
        Vector3 camRight = cam.transform.right; camRight.y = 0f; camRight = camRight.normalized;
        movement = (camForward * move.x + camRight * move.y).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(movement);
        if (movement.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.15f);
        }
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
