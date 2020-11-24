using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for core logic of main canvas (hud)
/// </summary>
public class CanvasScript : MonoBehaviour
{
    /// <summary>
    /// Reference to text which shows on win
    /// </summary>
    public Text winText;

    /// <summary>
    /// Reference to text which shows on loss
    /// </summary>
    public Text lossText;

    /// <summary>
    /// n of ticks that the loss text has been displayed
    /// </summary>
    private int lossTextDisplayTicks = 0;

    /// <summary>
    /// n of ticks the loss text exists before being disabled
    /// </summary>
    public int maxLossTextDisplayTicks = 100;

    /// <summary>
    /// n of ticks that the win text has been displayed
    /// </summary>
    private int winTextDisplayTicks = 0;

    /// <summary>
    /// n of ticks the win text exists before being disabled
    /// </summary>
    public int maxWinTextDisplayTicks = 100;

    /// <summary>
    /// set to TRUE when displaying win text
    /// </summary>
    private bool displayWinText = false;

    /// <summary>
    /// set to TRUE when displaying loss text
    /// </summary>
    private bool displayLossText = false;

    /// <summary>
    /// Counts n of ticks that either win/loss text has been displayed for. 
    /// Once reaching their max n, they are disabled.
    /// </summary>
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

    /// <summary>
    /// Called when the player has won, sets displayWinText to TRUE
    /// </summary>
    public void onWin()
    {
        displayWinText = true;
    }

    /// <summary>
    /// Called when the player has lost, sets displayLossText to TRUE
    /// </summary>
    public void onLoss()
    {
        displayLossText = true;
    }
        
}
