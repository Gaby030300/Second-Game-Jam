using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 40.0f;
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
