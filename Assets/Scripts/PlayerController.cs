using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public bool canJump;
    public float jumpForce;
    public InputAction jump;
    Rigidbody rb;
    // Start is called once bef1ore the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnEnable()
    {
        jump.Enable();
        jump.performed += Jump;
    }

    private void OnDisable()
    {
        jump.Disable();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
