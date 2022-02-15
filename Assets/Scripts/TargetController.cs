using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private Transform selfTransform;

    private void Start()
    {
        selfTransform = GetComponent<Transform>();
    }

    private void Update()
    {
     //   Vector3.MoveTowards();
    }
}
