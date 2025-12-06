using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float rotationSpeed = 10f;
    public float gravity = -9.81f;
    public Transform cameraTransform;
    
    public AudioSource footstepSource;
    public AudioClip[] footstepSounds;
    public float stepRate = 0.4f; // 1 pas chaque 0.4 sec
    private float stepTimer = 0f;


    private CharacterController controller;
    private Vector3 velocity;
    private bool isSoundPlay = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!Application.isPlaying)
            return;

        float h = Input.GetAxisRaw("Horizontal"); // A/D
        float v = Input.GetAxisRaw("Vertical");   // W/S

        // 🔥 Inverser uniquement W/S 🔥
        v = -v;

        // Direction camera -> player
        Vector3 camDir = cameraTransform.position - transform.position;
        camDir.y = 0f;
        camDir.Normalize();

        // Right vector stays correct
        Vector3 camRight = -Vector3.Cross(Vector3.up, camDir);

        // Movement relative to camera orbit
        Vector3 move = camDir * v + camRight * h;

        if (move.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            float angle = Mathf.LerpAngle(
                transform.eulerAngles.y,
                targetAngle,
                rotationSpeed * Time.deltaTime
            );

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(move.normalized * speed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;
        
        // --- SIMPLE FOOTSTEP SYSTEM ---
        bool isMoving = controller.isGrounded && move.magnitude > 0.1f;

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                stepTimer = stepRate; // reset timer

                if (footstepSounds.Length > 0 && !isSoundPlay)
                {
                    footstepSource.PlayOneShot(
                        footstepSounds[Random.Range(0, footstepSounds.Length)]
                    );
                    isSoundPlay = true;
                }
            }
        }
        else
        {
            footstepSource.Stop();
            stepTimer = 0f;
            isSoundPlay = false;
        }
    }
}