using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("MoveMent")]
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    [Header("Visual / Animator")]
    public Transform visual;
    private Animator animator;

    CharacterSpecSO spec;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = visual.GetComponent<Animator>();   // ✔ ใช้ Animator บน Visual เท่านั้น!
    }

    void Start()
    {
        spec = GameSession.Instance.selectedCharacter;
        moveSpeed = spec.moveSpeed;
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        // ส่งค่าให้ Animator
        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveY", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        // ✔ ฟลิปเฉพาะ visual เท่านั้น
        if (moveInput.x > 0.1f)
            visual.localScale = new Vector3(3, 3, 3);
        else if (moveInput.x < -0.1f)
            visual.localScale = new Vector3(-3, 3, 3);

        // ✔ Trigger skill
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
