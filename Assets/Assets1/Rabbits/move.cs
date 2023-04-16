using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class move : MonoBehaviour
{
    public float moveSpeed = 1f;
    // 刚体属性
    private Rigidbody rb;
    // 动画属性
    private Animator animator;
    // 位置移动
    private Vector3 targetPos;
    // 控制是否移动的bool变量
    private bool isMove;
    // 在开始的一帧执行的函数
    public int score = 0;
    public GameObject sco;
    public GameObject winn;
    public AudioSource music;
    // public AudioSource music;
    //public Text text;
    void Start()
    {
        // 获取当前物体的刚体属性
        rb = GetComponent<Rigidbody>();
        // 获取当前物体的动画属性
        animator = GetComponent<Animator>();
        winn.SetActive(false);
        music = GetComponent<AudioSource>();
        //music.Stop();
    }
    // 刷新的每一帧执行的函数
    void Update()
    {
        // 接收键盘操作函数
        Run();
        // 移动状态
        if (isMove)
        {
            // 这里的Run是之前我们创建的状态转换的那个参数的名字，根据自己的设置修改
            animator.SetBool("Run", isMove);
            // 实现人物的移动
            rb.velocity = transform.forward * moveSpeed * 1.1f;
            // 在距离目标的地点很近的时候（0.1f），停止移动
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                rb.velocity = Vector3.zero;
                isMove = false;
                animator.SetBool("Run", isMove);
            }
        }
    }

    void Run()
    {
        // 处理点击w前移逻辑
        if (Input.GetKey(KeyCode.W))
        {
            targetPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 1);
            // 转向
            transform.LookAt(targetPos);
            //改变移动State
            isMove = true;
        }
        // 处理点击a左移逻辑
        if (Input.GetKey(KeyCode.A))
        {
            //记录下目标点
            targetPos = new Vector3(transform.localPosition.x + 1, transform.localPosition.y, transform.localPosition.z);
            // 转向
            transform.LookAt(targetPos);
            //改变移动State
            isMove = true;
        }
        // 处理点击s后移逻辑
        if (Input.GetKey(KeyCode.S))
        {
            //记录下目标点
            targetPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 1);
            // 转向
            transform.LookAt(targetPos);
            //改变移动State
            isMove = true;
        }

        // 处理点击D右移逻辑
        if (Input.GetKey(KeyCode.D))
        {
            // 记录下目标点
            targetPos = new Vector3(transform.localPosition.x - 1, transform.localPosition.y, transform.localPosition.z);
            // 转向
            transform.LookAt(targetPos);
            // 改变移动状态
            isMove = true;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "carrot")
        {
            Destroy(collision.collider.gameObject);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "carrot")
        {
            music.Play();
            score++;
            //music.play();
            sco.GetComponent<TMP_Text>().text = "Score:" + score.ToString()+"/10";
            if (score == 10)
            {
                winn.SetActive(true);
                Time.timeScale = 0;

            }
            Destroy(collider.gameObject);
        }
    }
}
