using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerScript : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public Transform StartWaypoint;
    public List<GameObject> PlayerGameObjectList = new List<GameObject>();

    private SpriteRenderer prefabSpriteRenderer;
    private GameManagerScript gameManager;
    private List<Transform> sceneWaypoints = new List<Transform>();

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        foreach (GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            sceneWaypoints.Add(waypoint.GetComponent<Transform>());
        }

        foreach (Player player in gameManager.PlayerList)
        {
            GameObject temporaryPlayer = null;
            temporaryPlayer = PlayerPrefab;
            temporaryPlayer.name = player.nick;
            prefabSpriteRenderer = temporaryPlayer.GetComponent<SpriteRenderer>();
            prefabSpriteRenderer.sprite = player.counterGraphics;
            temporaryPlayer.GetComponent<PlayerMovement>().waypoints = sceneWaypoints;
            Instantiate(temporaryPlayer, new Vector2(StartWaypoint.transform.position.x, StartWaypoint.transform.position.y), Quaternion.identity);
            
        }

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            PlayerGameObjectList.Add(player);
        }
    }
}