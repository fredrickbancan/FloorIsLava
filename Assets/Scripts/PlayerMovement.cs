using UnityEngine;

/// <summary>
/// Class for movement of player (Keyboard and android touch)
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// ref to player rigidbody for physics
    /// </summary>
    public Rigidbody playerBody;

    /// <summary>
    /// ref to player transform for movement
    /// </summary>
    public Transform playerTransform;

    /// <summary>
    /// ref to android touch input script
    /// </summary>
    [SerializeField]
    private Android_GUIScript androidTouch;

    /// <summary>
    /// How much to rotate the player when android touch button for turning left/right is down.
    /// </summary>
    public float playerRotationAmount = 1.0F;

    /// <summary>
    /// editable value to determine the power of the players jump
    /// </summary>
    public float jumpForce;

    /// <summary>
    /// editable value to determine the speed of player movement
    /// </summary>
    public float walkSpeed;

    /// <summary>
    /// editable value to determine the players maximum horizontal velocity
    /// </summary>
    public float maxVel;


    bool isJumping = false;
    bool isWalkingFowards = false;
    bool isWalkingBack = false;
    bool isStrafingRight = false;
    bool isStrafingLeft = false;
    bool isGrounded = true;
  
    /// <summary>
    /// Detects if the player is grounded using multiple raycasts below the player.
    /// If the player is grounded, then depending on input keys or touch screen buttons being pressed, they will move, jump and/or rotate.
    /// </summary>
    void Update()
    {
        //using rays on every bottom corner and edge of the player box to determine if they are standing on the ground.
        isGrounded = 
            Physics.Raycast(new Ray(playerTransform.position + new Vector3(0.5F, -0.2F, 0), Vector3.down), 0.5F) ||
            Physics.Raycast(new Ray(playerTransform.position + new Vector3(-0.5F, -0.2F, 0), Vector3.down), 0.5F) ||
            Physics.Raycast(new Ray(playerTransform.position + new Vector3(0.0F, -0.2F, 0.5F), Vector3.down), 0.5F) ||
            Physics.Raycast(new Ray(playerTransform.position + new Vector3(0.0F, -0.2F, -0.5F), Vector3.down), 0.5F) ||

            Physics.Raycast(new Ray(playerTransform.position + new Vector3(0.5F, -0.2F, 0.5F), Vector3.down), 0.5F) ||
            Physics.Raycast(new Ray(playerTransform.position + new Vector3(-0.5F, -0.2F, -0.5F), Vector3.down), 0.5F) ||
            Physics.Raycast(new Ray(playerTransform.position + new Vector3(-0.5F, -0.2F, 0.5F), Vector3.down), 0.5F) ||
            Physics.Raycast(new Ray(playerTransform.position + new Vector3(0.5F, -0.2F, -0.5F), Vector3.down), 0.5F);
        isJumping = Input.GetKeyDown(KeyCode.Space);
        isWalkingFowards = Input.GetKey(KeyCode.W);
        isWalkingBack = Input.GetKey(KeyCode.S);
        isStrafingRight = Input.GetKey(KeyCode.D);
        isStrafingLeft = Input.GetKey(KeyCode.A);
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if(isGrounded)
        {
            if (isJumping)
            {
                playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            if (isWalkingFowards)
            {
                playerBody.velocity += playerTransform.forward * walkSpeed;
            }
            if (isWalkingBack)
            {
                playerBody.velocity -= playerTransform.forward * walkSpeed;
            }
            if (isStrafingRight)
            {
                playerBody.velocity += playerTransform.right * walkSpeed;
            }
            if (isStrafingLeft)
            {
                playerBody.velocity -= playerTransform.right * walkSpeed;
            }
        }

        UpdateAndroidInput(); 


        float prevy = playerBody.velocity.y;
        playerBody.velocity = Vector3.ClampMagnitude(new Vector3(playerBody.velocity.x, 0, playerBody.velocity.z), maxVel);
        playerBody.velocity = new Vector3(playerBody.velocity.x, prevy, playerBody.velocity.z);

    }

    /// <summary>
    /// Moves the player based on the android touch inputs
    /// </summary>
    void UpdateAndroidInput()
    {
        Vector4 values = androidTouch.GetInputValues();
        if (isGrounded)
        {
            if (values.x != 0)//movefowards
            {
                playerBody.velocity += playerTransform.forward * walkSpeed;
            }
            if (values.y != 0)//moveBack
            {
                playerBody.velocity -= playerTransform.forward * walkSpeed;
            }
            if(androidTouch.jumping)
            {
                playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                androidTouch.jumping = false;
            }
        }
        if (values.z != 0)//rotateLeft
        {
            Vector3 ang = playerTransform.eulerAngles;
            ang.y -= playerRotationAmount;
            playerTransform.rotation = Quaternion.Euler(ang);
        }
        if (values.w != 0)//rotateRight
        {
            Vector3 ang = playerTransform.eulerAngles;
            ang.y += playerRotationAmount;
            playerTransform.rotation = Quaternion.Euler(ang);
        }
    }
}
