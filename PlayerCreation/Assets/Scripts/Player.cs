using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    public string nick;
    public Sprite counterGraphics;

    public Player (string _nick, Sprite _counterGraphics)
    {
        nick = _nick;
        counterGraphics = _counterGraphics;
    }
}
