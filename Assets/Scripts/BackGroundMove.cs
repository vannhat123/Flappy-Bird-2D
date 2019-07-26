using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public float moveSpeed= 5;

    public float moveRange =20;

    private GameObject obj;
  
    private Vector3 oldPosition;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1* Time.deltaTime* moveSpeed, transform.position.y, 0));
        if (Vector3.Distance(oldPosition, obj.transform.position) > moveRange)
        {
            obj.transform.position = oldPosition;
        }
    }
}
