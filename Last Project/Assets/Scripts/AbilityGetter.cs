using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityGetter : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isDashAvaliable = true;
            Destroy(gameObject);
        }    
    }
}
