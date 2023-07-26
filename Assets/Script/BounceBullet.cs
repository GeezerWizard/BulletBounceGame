using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBullet : MonoBehaviour
{
    [SerializeField] private Vector2 arenaSize;

    public float arenaX{ get { return arenaSize.x; } }
    public float arenaY{ get { return arenaSize.y; } }
}
