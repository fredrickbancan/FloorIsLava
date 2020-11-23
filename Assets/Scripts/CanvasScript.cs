using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Text winText;
    public Text lossText;

    private int lossTextDisplayTicks = 0;
    public int maxLossTextDisplayTicks = 100;
    private int winTextDisplayTicks = 0;
    public int maxWinTextDisplayTicks = 100;
    private bool displayWinText = false;
    private bool displayLossText = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (displayLossText)
        {
            lossTextDisplayTicks++;
            if (lossTextDisplayTicks >= maxLossTextDisplayTicks)
            {
                lossTextDisplayTicks = 0;
                displayLossText = false;
            }
        }
        else
        {
            lossTextDisplayTicks = 0;
        }

        if (displayWinText)
        {
            winTextDisplayTicks++;
            if (winTextDisplayTicks >= maxWinTextDisplayTicks)
            {
                lossTextDisplayTicks = 0;
                displayWinText = false;
            }
        }
        else
        {
            winTextDisplayTicks = 0;
        }

        lossText.enabled = displayLossText;
        winText.enabled = displayWinText;
    }

    public void onWin()
    {
        displayWinText = true;
    }
    public void onLoss()
    {
        displayLossText = true;
    }
        
}
