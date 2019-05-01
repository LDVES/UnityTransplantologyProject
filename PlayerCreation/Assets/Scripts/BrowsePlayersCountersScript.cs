using UnityEngine;
using UnityEngine.UI;

public class BrowsePlayersCountersScript : MonoBehaviour
{
    public Sprite[] CounterGraphics;
    public Image PlayerPanelGraphics;

    private int index;

    public void SwichImageToRight()
    {
        if (index < CounterGraphics.Length - 1)
        {
            index++;
            SetPanelGraphicsToIndex();
        }
        else
        {
            index = 0;
            SetPanelGraphicsToIndex();
        }
    }

    public void SwichImageToLeft()
    {
        if (index >= 1)
        {
            index--;
            SetPanelGraphicsToIndex();
        }
        else
        {
            index = CounterGraphics.Length - 1;
            SetPanelGraphicsToIndex();
        }
    }

    private void SetPanelGraphicsToIndex()
    {
        PlayerPanelGraphics.sprite = CounterGraphics[index];
    }

    public void SetPanelGraphics(int graphicsIndex)
    {
        PlayerPanelGraphics.sprite = CounterGraphics[graphicsIndex];
    }
}
