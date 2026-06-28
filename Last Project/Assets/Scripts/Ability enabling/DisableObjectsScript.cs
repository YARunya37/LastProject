using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectsScript : MonoBehaviour
{
    [SerializeField] List<GameObject> toDisable;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            foreach (var gameObject in toDisable)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
