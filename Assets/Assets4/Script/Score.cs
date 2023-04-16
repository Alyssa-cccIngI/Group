using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {
    //Score
    public int score;
    public static Score instance;
    public Text ScoreText;
    //Win
    public GameObject win;
    //Failure
    public GameObject lose;
    //Sound 
    AudioSource audioSource;
    public AudioSource audioSource1;
    //Full mark
    public int fenshu;
    // Use this for initialization
    void Start () {

        //Get sound
        audioSource = transform.GetComponent<AudioSource>();
        instance = this;
    }
	
	// Update
	void Update () {
        ScoreText.text = "Score:" + score;
        if (score == fenshu)
        {
            win.SetActive(true);
        }
        if (score <0)
        {
            lose.SetActive(true);
        }
    }
    public void AddScore(int amount)
    {
        score += amount;
        ScoreText.text = "Score:" + score;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            //Getsound and play music
            audioSource.Play();
            //Add 5 points
            score += 5;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Shi")
        {
            //Play music
            audioSource1.Play();
            //Deduct 5 points
            score -= 5;
         
        }
    }
}
