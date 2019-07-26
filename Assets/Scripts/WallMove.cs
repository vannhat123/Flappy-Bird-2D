using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class WallMove : MonoBehaviour
{
    // dat bien float cho minY maxY de no thay doi tu do kieu float
    public float moveSpeed;
    public float minY;
    public float maxY;
    

    private GameObject obj;

    private float oldPosition;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = 10;
        moveSpeed = 5;
        minY = -1;
        maxY = 1;

    }

    // Update is called once per frame
    // tốc độ di chuyển của tường luôn luôn
    void Update()
    {
        obj.transform.Translate(new Vector3(-1* Time.deltaTime* moveSpeed, 0, 0));
       
    }

    // vì khoảng  cách di chuyển trục y cần -1 đến max Y +1.
    // chọn if vì nếu chạm cái Reset Wall thì nó mới lặp lại vì không thì con chim trạm vào wall cũng là trigger.
    // chạm đến  Reset Wall thì sẽ tự động quay lại giá trị x cũ.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Reset Wall"))
        {
            obj.transform.position = new Vector3(oldPosition,Random.Range(minY, maxY+1), 0);
        }
    }
}
