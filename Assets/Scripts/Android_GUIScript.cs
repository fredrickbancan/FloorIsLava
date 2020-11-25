using UnityEngine;
using UnityEngine.UI;

public class Android_GUIScript : MonoBehaviour
{

    [SerializeField]
    private Button moveFowardsButton;
    [SerializeField]
    private Button rotateLeftButton;
    [SerializeField]
    private Button rotateRightButton;
    [SerializeField]
    private Button moveBackwardsButton;
    [SerializeField]
    private Button jumpButton;
    [SerializeField]
    private Rigidbody playerBody;
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float playerRotationAmount = 15.0F;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMoveFowardsButtonPress()
    {
        
    }
}
