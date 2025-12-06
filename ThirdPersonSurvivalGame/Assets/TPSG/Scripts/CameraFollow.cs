using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 10f;

    private void LateUpdate()
    {
        if (!Application.isPlaying || target == null)
            return;

        Vector3 desiredPos = target.position;
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPos,
            smoothSpeed * Time.deltaTime
        );

        if (target.parent != null)
            transform.LookAt(target.parent);
        else
            transform.LookAt(target);
    }
}