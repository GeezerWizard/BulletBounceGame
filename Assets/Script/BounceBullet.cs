using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBullet : MonoBehaviour
{
    [SerializeField] private Vector2 arenaSize;

    public float arenaX{ get { return arenaSize.x; } }
    public float arenaY{ get { return arenaSize.y; } }

    private void Update() {
        float halfArenaX = arenaX*0.5f;
        float halfArenaY = arenaY*0.5f;
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
