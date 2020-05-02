using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayer : MonoBehaviour
{

    [SerializeField] GameObject nave;
    // Start is called before the first frame update
    void Start()
    {
        
        //GameObject obj = Instantiate(nave, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.Euler(0, 0, 90));
        //obj.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
