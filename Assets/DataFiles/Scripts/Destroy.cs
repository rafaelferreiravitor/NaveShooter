using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [Tooltip("Set the lifetime")] [SerializeField] float time = 5;
    private void Awake()
    {
        Destroy(gameObject, time);
    }
    
}
