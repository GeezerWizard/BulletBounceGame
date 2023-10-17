using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class UIWorldSpaceFollow : MonoBehaviour
{
    [SerializeField] Transform transformToFollow;
    [SerializeField] bool keepOffset;
    [SerializeField] bool freezeX, freezeY, freezeZ;
    [SerializeField] Vector3 offset;
    Vector3 freezeAxis;

    void Start()
    {
        freezeAxis = new Vector3(Convert.ToInt16(!freezeX), Convert.ToInt16(!freezeY), Convert.ToInt16(!freezeZ));
    }
    
    void Update()
    {
        this.transform.localPosition = Vector3.Scale(transformToFollow.localPosition, freezeAxis) + offset;
    }
}
