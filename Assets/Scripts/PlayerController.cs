using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public bool canJump;
    public float jumpForce;
    public InputAction jump;

    public int score = 0;
    public int highScore = 0;
    Rigidbody rb;
    // Start is called once bef1ore the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        highScore=PlayerPrefs.GetInt("HighScore");

    }

    private void OnEnable()
    {
        jump.Enable();
    }

    private void OnDisable()
    {
        jump.Disable();
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log("Jump");
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (jump.triggered && canJump)
        {
            Jump();
        }
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);;
            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("3D Endless Runner");
        }
        else if(other.gameObject.tag == "Score")
        {
            score++;
            Debug.Log(score);
        }
    }
}
