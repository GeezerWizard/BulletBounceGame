using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBullet : MonoBehaviour
{
    [SerializeField] private Vector2 arenaSize;
    [SerializeField] private Transform[] boundryWalls;
    [SerializeField] private Transform floor;

    public float arenaX{ get { return arenaSize.x; } }
    public float arenaY{ get { return arenaSize.y; } }

    private float halfArenaX;
    private float halfArenaY;

    private float padding = 1;

    private void Start() {
        halfArenaX = arenaX*0.5f;
        halfArenaY = arenaY*0.5f;

        foreach (Transform wall in boundryWalls)
        {
            wall.position = Vector3.zero;
            wall.localScale = Vector3.one;
        }

        floor.localScale = new Vector3(arenaX - padding, arenaY - padding, 1);


        //Top Boundry
        boundryWalls[0].position += new Vector3(0, halfArenaY + padding, 0);
        boundryWalls[0].localScale = new Vector3(arenaSize.x + 3, 1, 1);
        //Bottom Boundry
        boundryWalls[1].position -= new Vector3(0, halfArenaY + padding, 0);
        boundryWalls[1].localScale = new Vector3(arenaSize.x + 3, 1, 1);
        //Right Boundry
        boundryWalls[2].position += new Vector3(halfArenaX + padding, 0, 0);
        boundryWalls[2].localScale = new Vector3(1, arenaSize.y + 3, 1);
        //Left Boundry
        boundryWalls[3].position -= new Vector3(halfArenaX + padding, 0, 0);
        boundryWalls[3].localScale = new Vector3(1, arenaSize.y + 3, 1);
    }

    private void Update() {
        Vector2[] path = new Vector2[] { new Vector2(halfArenaX, halfArenaY), new Vector2(-halfArenaX, halfArenaY), new Vector2(-halfArenaX, -halfArenaY), new Vector2(halfArenaX, -halfArenaY) };
        for (int i = 0; i < path.Length; i++)
        {
            int nextPath = i++;
            if (nextPath > path.Length)
            {
                nextPath = 0;
            }
            Debug.DrawLine(path[i], path[nextPath]);
        }
    }
}
