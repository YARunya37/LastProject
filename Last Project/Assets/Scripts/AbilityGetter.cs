using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityGetter : MonoBehaviour
{
    [SerializeField] AudioSource au;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            au.Play();
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().isDashAvaliable = true;            
            Destroy(gameObject);            
        }    
    }
}
