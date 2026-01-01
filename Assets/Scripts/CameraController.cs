using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 150f;
    public float minY = -30f;
    public float maxY = 60f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minY, maxY);

        yRotation += mouseX;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        // Keep camera centered on player
        transform.position = player.position + new Vector3(0, 1.5f, 0);
    }
}
