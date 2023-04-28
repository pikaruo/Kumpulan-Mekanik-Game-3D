using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerSpinWheelGame : MonoBehaviour
{

    public GameObject pointerCollect;

    // * This method for pointer reward
    private void OnTriggerEnter2D(Collider2D collider)
    {
        pointerCollect = collider.gameObject;
    }


}
