using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public string nextSceneName;
    public GameObject hitKey;
    // タイマー
    private UInt32 timer_ = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        // タイマーで文字を動かす
        timer_++;
        if(70  < timer_ % 100)
        {
            hitKey.SetActive(false);
        }
        else
        {
            hitKey.SetActive(true);
        }

    }
}
