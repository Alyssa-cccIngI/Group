using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public Text text;
    private int score = 0;
    private int fcore = 5;
    public GameObject winText;
    Animator ani;
    public AudioClip Music;
    public AudioSource theAS;

    public void Awake()
    {
        theAS = GetComponent<AudioSource>();
    }

    void Start()
    {
        ani = GetComponent<Animator>();
        
    }
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);
            transform.Translate(Vector3.forward * 1 * Time.deltaTime);
            ani.SetBool("isRun", true);
        }
        else
        {
            ani.SetBool("isRun", false);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "PickUp")
        {
            Destroy(collision.collider.gameObject);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "PickUp")
        {
            theAS.Play();
            score++;
            text.text = score.ToString();
            if (score == 5) {
                winText.SetActive(true);

            }
            Destroy(collider.gameObject);
        }
        
    }
}