using UnityEngine;

/// <summary>
/// Script for integration of android touch screen buttons
/// </summary>
public class Android_GUIScript : MonoBehaviour
{

    /// <summary>
    /// Touchscreen input button reference
    /// </summary>
    [SerializeField]
    private TouchButton moveFowardsButton;

    /// <summary>
    /// Touchscreen input button reference
    /// </summary>
    [SerializeField]
    private TouchButton rotateLeftButton;

    /// <summary>
    /// Touchscreen input button reference
    /// </summary>
    [SerializeField]
    private TouchButton rotateRightButton;

    /// <summary>
    /// Touchscreen input button reference
    /// </summary>
    [SerializeField]
    private TouchButton moveBackwardsButton;

    /// <summary>
    /// Touchscreen input button reference
    /// </summary>
    [SerializeField]
    private TouchButton jumpButton;

    /// <summary>
    /// Vector4 to keep track of all input buttons
    /// </summary>
    private Vector4 inputValues = new Vector4();

    /// <summary>
    /// Vector4 to keep track of jump
    /// </summary>
    public bool jumping = false;

    /// <summary>
    /// Add all listeners to buttons
    /// </summary>
    void Start()
    {
        moveFowardsButton.onButDown.AddListener(OnMoveFowardsButtonDown);
        moveFowardsButton.onButUp.AddListener(OnMoveFowardsButtonUp);
        moveBackwardsButton.onButDown.AddListener(OnMoveBackwardsButtonDown);
        moveBackwardsButton.onButUp.AddListener(OnMoveBackwardsButtonUp);
        rotateLeftButton.onButDown.AddListener(OnRotateLeftButtonDown);
        rotateLeftButton.onButUp.AddListener(OnRotateLeftButtonUp);
        rotateRightButton.onButDown.AddListener(OnRotateRightButtonDown);
        rotateRightButton.onButUp.AddListener(OnRotateRightButtonUp);
        jumpButton.onButDown.AddListener(OnJumpButton);
    }

    /// <summary>
    /// Listener function for button to allow touch input
    /// </summary>
     void OnMoveFowardsButtonDown()
    {
        inputValues.x = 1.0F;
    }

    /// <summary>
    /// Listener function for button to allow touch input
    /// </summary>
     void OnMoveFowardsButtonUp()
    {
        inputValues.x = 0.0F;
    }

    /// <summary>
    /// Listener function for button to allow touch input
    /// </summary>
     void OnMoveBackwardsButtonDown()
    {
        inputValues.y = 1.0F;
    }

    /// <summary>
    /// Listener function for button to allow touch input
    /// </summary>
     void OnMoveBackwardsButtonUp()
    {
        inputValues.y = 0.0F;
    }

    /// <summary>
    /// Listener function for button to allow touch input
    /// </summary>
     void OnRotateLeftButtonDown()
    {
        inputValues.z = 1.0F;
    }

    /// <summary>
    /// Listener function for button to allow touch input
    /// </summary>
     void OnRotateLeftButtonUp()
    {
        inputValues.z = 0.0F;
    }

    /// <summary>
    /// Listener function for button to allow touch input
    /// </summary>
     void OnRotateRightButtonDown()
    {
        inputValues.w = 1.0F;
    }

    /// <summary>
    /// Listener function for button to allow touch input
    /// </summary>
     void OnRotateRightButtonUp()
    {
        inputValues.w = 0.0F;
    }

    /// <summary>
    /// Listener function for button to allow touch input
    /// </summary>
     void OnJumpButton()
    {
        jumping = true;
    }

    public Vector4 GetInputValues()
    {
        return inputValues;
    }
}
