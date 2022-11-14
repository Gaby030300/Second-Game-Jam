using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topLimit;

    // Update is called once per frame
    void Update()
    {
        // Destroy balls if y position is less than bottomLimit
        if (transform.position.x < topLimit)
        {
            Destroy(gameObject);
        }
    }
}
