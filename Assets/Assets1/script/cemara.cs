using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cemara : MonoBehaviour
{
	public Transform playerTransform;   //定义公共变量记录小球的位置信息
	private Vector3 offset;    //定义相机和小球之前的距离
							   // Use this for initialization
	void Start()
	{
		offset = transform.position - playerTransform.position;    //计算相机和小球之间距离
	}
	// Update is called once per frame
	void Update()
	{
		transform.position = playerTransform.position + offset;  //保持距离
	}
}
