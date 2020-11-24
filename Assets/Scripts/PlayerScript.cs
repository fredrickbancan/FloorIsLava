using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script for controlling core player logic
/// </summary>
public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// Canvas reference for UI events
    /// </summary>
    public CanvasScript cs;

    /// <summary>
    /// Reference to player gameobject
    /// </summary>
    public GameObject player;

    /// <summary>
    /// Number of updates that have passed since a win/loss event
    /// </summary>
    private int ticksSinceWinLoss = 0;

    /// <summary>
    /// Number of updates that need to pass after win/loss before game restarts
    /// </summary>
    public int maxRespawnTicks = 500;

    /// <summary>
    /// Boolean for if the player has won or lost.
    /// </summary>
    private bool hasWonOrLost = false;

    /// <summary>
    /// Function increases ticksSinceWinLoss var if hasWonOrLost is equal to TRUE. 
    /// Once ticksSinceWinLoss is equal or greater than maxRespawnTicks, the game is unpaused and restarted.
    /// </summary>
    void Update()
    {
        if(hasWonOrLost)
        {
            ticksSinceWinLoss++;
            if(ticksSinceWinLoss >= maxRespawnTicks)
            {
                ticksSinceWinLoss = 0;
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    /// <summary>
    /// Checks if player has touched either the lava plane or the finish trigger.
    /// Depending which, will pause the game and call cs.onWin()/cs.onLoss(). 
    /// Sets hasWonOrLost to TRUE and sets Time.timeScale to 0 to effectively pause game untill respawn.
    /// </summary>
    /// <param name="other">Object collided with</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")//end touch
        {
            cs.onWin();
            hasWonOrLost = true;
            Time.timeScale = 0;
        }
        else if (other.tag == "Respawn")//lava touch
        {
            cs.onLoss();
            hasWonOrLost = true;
            Time.timeScale = 0;
        }
    }
}
