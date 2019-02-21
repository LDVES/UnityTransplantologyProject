using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    string nick;
    Image counterGraphics;

    public Player (string _nick, Image _counterGraphics)
    {
        nick = _nick;
        counterGraphics = _counterGraphics;
    }
}
