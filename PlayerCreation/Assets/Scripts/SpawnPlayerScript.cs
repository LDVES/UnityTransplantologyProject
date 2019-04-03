using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerScript : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public Transform StartWaypoint;
    public List<GameObject> PlayerGameObjectList = new List<GameObject>();
    public List<Transform> Waypoints = new List<Transform>();

    private SpriteRenderer prefabSpriteRenderer;
    private GameManagerScript gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        foreach (Player player in gameManager.PlayerList)
        {
            GameObject temporaryPlayer = null;
            temporaryPlayer = PlayerPrefab;
            temporaryPlayer.name = player.nick;
            prefabSpriteRenderer = temporaryPlayer.GetComponentInChildren<SpriteRenderer>();
            prefabSpriteRenderer.sprite = player.counterGraphics;
            temporaryPlayer.GetComponent<PlayerMovement>().waypoints = Waypoints;
            GameObject instantiatedPlayer =  Instantiate(temporaryPlayer, new Vector2(StartWaypoint.transform.position.x, StartWaypoint.transform.position.y), Quaternion.identity);
            instantiatedPlayer.name = player.nick;

        }

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            PlayerGameObjectList.Add(player);
        }
    }
}