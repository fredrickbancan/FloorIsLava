using UnityEngine;

/// <summary>
/// Class for core logic of lava plane
/// </summary>
public class lavaScript : MonoBehaviour
{
    /// <summary>
    /// Ref to lava plane transform for moving it
    /// </summary>
    public Transform lavaTransform;

    /// <summary>
    /// height value of lava plane when it starts
    /// </summary>
    public float startHeight = -10.0F;

    /// <summary>
    /// number of units the lava plane moves each update vertically
    /// </summary>
    public float moveSpeed = 0.01F;

   /// <summary>
   /// Sets the lava height to the startHeight value
   /// </summary>
    void Start()
    {
        lavaTransform.position = new Vector3(0, startHeight, 0);
    }

   /// <summary>
   /// Increases the lava plane height by moveSpeed units each update
   /// </summary>
    void Update()
    {
        Vector3 h = lavaTransform.position;
        h.y += moveSpeed;
        lavaTransform.position = h;
    }
}
