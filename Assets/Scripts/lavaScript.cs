using UnityEngine;

public class lavaScript : MonoBehaviour
{
    public Transform lavaTransform;
    public Collider lavaCol;
    public Collider playerCol;
    public float startHeight = -10.0F;
    public float moveSpeed = 0.01F;

    // Start is called before the first frame update
    void Start()
    {
        lavaTransform.position = new Vector3(0, startHeight, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 h = lavaTransform.position;
        h.y += moveSpeed;
        lavaTransform.position = h;
    }
}
