using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlressRunCoin : MonoBehaviour
{

    private void FixedUpdate()
    {
        transform.Rotate(50 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            EndlessRunGameManager.collectCoin += 1;
            Destroy(gameObject);
        }
    }

}