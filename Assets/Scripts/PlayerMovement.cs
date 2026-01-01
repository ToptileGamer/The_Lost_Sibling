using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float rotationSpeed = 10f;

    private CharacterController controller;
    private Transform cam;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputDir = new Vector3(h, 0, v);
        float moveAmount = Mathf.Clamp01(inputDir.magnitude);

        animator.SetFloat("Speed", moveAmount * speed);

        if (moveAmount >= 0.1f)
        {
            Vector3 camForward = cam.forward;
            Vector3 camRight = cam.right;

            camForward.y = 0;
            camRight.y = 0;

            Vector3 moveDir = camForward * v + camRight * h;

            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotationSpeed * Time.deltaTime
            );

            controller.Move(moveDir * speed * Time.deltaTime);
        }
    }
}
