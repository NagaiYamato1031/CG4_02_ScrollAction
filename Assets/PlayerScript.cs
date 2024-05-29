using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public Rigidbody rb;
	public float moveSpeed = 2.0f;
	public float jumpSpeed = 100.0f;

	private bool isFloating = false;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// レイを出す
		Vector3 rayPos = transform.position;
		Ray ray = new Ray(rayPos, Vector3.down);
		float distance = 0.6f;
		//Debug.DrawRay(rayPos, Vector3.down * distance, isFloating ? Color.red : Color.yellow);

		isFloating = !Physics.Raycast(ray, distance);

		if (GoalScript.isGameClear)
		{
			return;
		}
		Vector3 v = rb.velocity;
		// 横移動
		if (Input.GetKey(KeyCode.RightArrow) ||
			Input.GetKey(KeyCode.D))
		{
			v.x = moveSpeed;
		}
		else if (Input.GetKey(KeyCode.LeftArrow) ||
			Input.GetKey(KeyCode.A))
		{
			v.x = -moveSpeed;
		}
		else
		{
			v.x = 0;
		}

		// ジャンプ
		if (!isFloating && Input.GetKeyDown(KeyCode.Space))
		{
			v.y = jumpSpeed;
		}

		rb.velocity = v;
	}

}
