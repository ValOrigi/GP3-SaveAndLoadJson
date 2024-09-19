using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Destroy : MonoBehaviour
{
    private SaveAndLoading svl;

    private void Start()
    {
        svl = GameObject.FindGameObjectWithTag("GameController").GetComponent<SaveAndLoading>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            svl.enemyNames.Add(collision.gameObject.name);
            svl.initialSpawn.Remove(collision.gameObject.transform.position);
            collision.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
