using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int GameLength;
    [SerializeField]
    public List<Player> PlayerList = new List<Player>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
