using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerScript : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public Transform StartWaypoint;

    private SpriteRenderer prefabSpriteRenderer;
    private GameManagerScript gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        foreach (Player player in gameManager.PlayerList)
        {
            PlayerPrefab.name = player.nick;
            prefabSpriteRenderer = PlayerPrefab.GetComponent<SpriteRenderer>();
            prefabSpriteRenderer.sprite = player.counterGraphics;
            Instantiate(PlayerPrefab, new Vector2(StartWaypoint.transform.position.x, StartWaypoint.transform.position.y), Quaternion.identity);
        }
    }
}