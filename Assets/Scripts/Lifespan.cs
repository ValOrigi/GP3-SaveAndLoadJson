using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifespan : MonoBehaviour
{
    public float TimeToLive;
    private void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
}
