using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
public class EnemyBaseClass : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector2(Random.Range(0, 5), Random.Range(0, 3));
    }
}