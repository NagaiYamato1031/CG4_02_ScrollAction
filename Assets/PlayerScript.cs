using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public Rigidbody rb;
	public float moveSpeed = 2.0f;
	public float jumpSpeed = 100.0f;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
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
		if (Input.GetKeyDown(KeyCode.Space))
		{
			v.y = jumpSpeed;
		}

		rb.velocity = v;
	}
}
