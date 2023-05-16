using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunCameraController : MonoBehaviour
{
    [Header("System Camera Follow")]
    [SerializeField] private Transform target;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 10 * Time.deltaTime);
    }
}
