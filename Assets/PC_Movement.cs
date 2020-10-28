using UnityEngine;

public class PC_Movement : MonoBehaviour
{
    public Rigidbody playerBody;
    public Transform playerTransform;
    public float jumpForce;
    public float walkSpeed;
    public float maxVel;
    bool isJumping = false;
    bool isWalkingFowards = false;
    bool isGrounded = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(new Ray(playerTransform.position + new Vector3(0.5F,-0.2F,0), Vector3.down), 0.5F) ||
            Physics.Raycast(new Ray(playerTransform.position + new Vector3(-0.5F, -0.2F, 0), Vector3.down), 0.5F) ||
            Physics.Raycast(new Ray(playerTransform.position + new Vector3(0.0F, -0.2F, 0.5F), Vector3.down), 0.5F) ||
            Physics.Raycast(new Ray(playerTransform.position + new Vector3(0.0F, -0.2F, -0.5F), Vector3.down), 0.5F);
        isJumping = Input.GetKeyDown(KeyCode.Space);
        isWalkingFowards = Input.GetKey(KeyCode.W);
        if(isJumping && isGrounded)
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if(isWalkingFowards && isGrounded)
        {
            playerBody.velocity += playerTransform.forward * walkSpeed;
        }
        playerBody.velocity = new Vector3(Mathf.Clamp(playerBody.velocity.x, -maxVel, maxVel), playerBody.velocity.y, Mathf.Clamp(playerBody.velocity.z, -maxVel, maxVel));
    }
}
