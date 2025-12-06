using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Player
    public float mouseSensitivity = 150f;
    public float distance = 4f;
    public float height = 1.7f;

    private float yaw;
    private float pitch;

    private void LateUpdate()
    {
        if (!Application.isPlaying || target == null)
            return;

        // Lire la souris
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -20f, 60f);

        // Calcul de la position caméra
        Quaternion rot = Quaternion.Euler(pitch, yaw, 0);
        Vector3 dir = rot * new Vector3(0, 0, -distance);
        Vector3 pos = target.position + Vector3.up * height + dir;

        transform.position = pos;
        transform.LookAt(target.position + Vector3.up * height);
    }
}