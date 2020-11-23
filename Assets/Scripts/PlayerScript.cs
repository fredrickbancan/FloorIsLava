using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public CanvasScript cs;
    public GameObject player;
    private int ticksSinceWinLoss = 0;
    public int maxRespawnTicks = 500;
    private bool hasWonOrLost = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
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
