using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityGetter : MonoBehaviour
{
    [SerializeField] AudioSource au;
    [SerializeField] GameObject toEnablePlate;
    [SerializeField] GameObject InputHint;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            au.Play();
            toEnablePlate.AddComponent<DashActivator>();
            var hint = toEnablePlate.GetComponent<HintDisplay>();
            hint.HideHint();
            hint.hintObject = InputHint;
            Destroy(gameObject);
        }
    }
}
