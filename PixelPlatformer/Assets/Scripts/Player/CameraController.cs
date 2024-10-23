using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private void Update()
    {
        transform.position = new Vector3(_playerTransform.position.x, _playerTransform.position.y, transform.position.z);
    }
}
