using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private CircleCollider2D collider;

    private void Start()
    {
        collider = gameObject.GetComponent<CircleCollider2D>();
    }
}
