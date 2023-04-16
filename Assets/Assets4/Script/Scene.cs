using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {
	void Start () {
		
	}
	
	void Update () {
		
	}
    public void S0()
    {
        SceneManager.LoadScene(0);
    }
    public void S1()
	{
		SceneManager.LoadScene(1);
	}
  
    public void Exit()
	{
		Application.Quit();
	}
}
