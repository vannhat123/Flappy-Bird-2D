using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirController : MonoBehaviour
{
    public float flyPower = 50;
    public AudioClip flyClip;
    public AudioClip gameOverClip;
    private AudioSource audioSource;
    private Animator anim;
    private GameObject obj;
    public GameObject gameController;
    // Start is called before the first frame update

    // Tạo biến audioSource rồi cho nó bằng giá trị Audioclip ở thành phần truy cập tới
    // Cho mặc định clip lúc đầu là chim sống. sau lúc chết gán cho clip gameover là được.
    void Start()
    {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = flyClip;
        anim = obj.GetComponent<Animator>();
        anim.SetFloat("flyPower",0);
        anim.SetBool("isDead", false);
        
        // Neu khong keo dat gameController vao thi no se tu keo vao cho.
        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    // AddForce tao them 1 luc Vector2
    // khi click chuột thì audioSource sẽ chạy là lúc sống
    // đặt thêm điều kiện khi GameCOntroller chưa kết thúc thì nó sẽ kêu.
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(!gameController.GetComponent<GameController>().isEndGame)
            audioSource.Play();
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,flyPower));
        }
        anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
    }
    // Khi chim va cham voi wall hoac grass se xay ra vi cung la collision
    private void OnCollisionEnter2D(Collision2D other)
    {
        EndGameBir();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameController.GetComponent<GameController>().GetPoint();
    }

    //void Foo(){} gán cho gameOverClip rồi chạy 
    public void EndGameBir()
    {
        anim.SetBool("isDead", true);
        audioSource.clip = gameOverClip;
        audioSource.Play();
        gameController.GetComponent<GameController>().EndGame();
    }
}
