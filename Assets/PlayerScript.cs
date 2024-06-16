using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public Rigidbody rb;
	public Animator animator;
	public float moveSpeed = 2.0f;
	public float jumpSpeed = 10.0f;
	public float addGravity = 0.05f;

	private bool isFloating = false;
	private AudioSource audioSource;

	private bool isLeft = false;

	// Start is called before the first frame update
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
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
		float stick = Input.GetAxis("Horizontal");
		// 横移動
		if (Input.GetKey(KeyCode.RightArrow) ||
			Input.GetKey(KeyCode.D) ||
			0 < stick)
		{
			v.x = moveSpeed;
			animator.SetBool("isMove", true);
			isLeft = false;
		}
		else if (Input.GetKey(KeyCode.LeftArrow) ||
			Input.GetKey(KeyCode.A) ||
			stick < 0)
		{
			v.x = -moveSpeed;
			animator.SetBool("isMove", true);
			isLeft = true;
		}
		else
		{
			animator.SetBool("isMove", false);
			v.x = 0;
		}

		// ジャンプ
		if (!isFloating && Input.GetButtonDown("Jump"))
		{
			v.y = jumpSpeed;
			animator.SetBool("jump", true);
		}
		// 追加重力
		else
		{
			v.y -= addGravity;
			animator.SetBool("jump", false);
		}

		rb.velocity = v;
		Quaternion rot = transform.rotation;
		rot.y = isLeft ? 180.0f : 0.0f;
		transform.rotation = rot;

		// フラグ
		animator.SetBool("isFloating", isFloating);
		if (transform.position.y < -10.0f)
			transform.position = new Vector3(1.0f, 5.0f, 0.0f);
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Coin")
		{
			other.gameObject.SetActive(false);
			audioSource.Play();
			GameManagerScript.score++;
		}
	}
}
