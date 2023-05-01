using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerSpinWheelGame : MonoBehaviour
{

    [Header("System Reward")]
    public GameObject pointerCollectReward;

    // * This method for pointer reward
    private void OnTriggerEnter2D(Collider2D collider)
    {
        pointerCollectReward = collider.gameObject;
    }


}
