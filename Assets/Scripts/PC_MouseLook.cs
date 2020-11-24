using UnityEngine;

/// <summary>
/// Class for controlling camera on PC (mouse input)
/// </summary>
public class PC_MouseLook : MonoBehaviour
{
    /// <summary>
    /// used for calculating mouse deltas
    /// </summary>
    private float prevMouseX = 0;

    /// <summary>
    /// used for calculating mouse deltas
    /// </summary>
   // private float prevMouseY = 0;

    /// <summary>
    /// used to control rotation of the player
    /// </summary>
    float yRot = 0.0f;

    /// <summary>
    /// Reference to player transform for rotating
    /// </summary>
    public Transform playerBody;

    /// <summary>
    /// Calculates mouse movement deltas, rotates the player accordingly.
    /// For this game, only horizontal rotations are desired.
    /// </summary>
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
       // float mouseY = Input.GetAxis("Mouse Y");

        float deltaMouseX = mouseX - prevMouseX;
      //  float deltaMouseY = mouseY - prevMouseY;
        yRot += deltaMouseX;
        playerBody.Rotate(Vector3.up * yRot);

        prevMouseX = mouseX;
      //  prevMouseY = mouseY;
    }
}
