using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collision : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rd;
    public int force = 5;

    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rd.AddForce(new Vector3(h, 0, v) * force);
    }
    //Åö×²¼ì²â
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "carrot")
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
