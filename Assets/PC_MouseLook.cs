using UnityEngine;

public class PC_MouseLook : MonoBehaviour
{
    float prevMouseX = 0;
    float prevMouseY = 0;
    float yRot = 0.0f;
    public Transform playerBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float deltaMouseX = mouseX - prevMouseX;
        float deltaMouseY = mouseY - prevMouseY;
        yRot += deltaMouseX;
        playerBody.Rotate(Vector3.up * yRot);

        prevMouseX = mouseX;
        prevMouseY = mouseY;
    }
}
