using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;
    public GameObject goal;
    public GameObject coin;
    public TextMeshProUGUI scoreText;

    // スコア
    public static int score = 0;

    int[,] map =
    {
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,3,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,3,0,0,0,0,3,0, 0,0,0,0,0,0,0,0,0,0, 0,0,3,0,0,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,0, 0,1,0,0,0,0,0,0,0,0, 0,0,0,0,3,0,0,0,0,0, 0,1,1,1,1,0,0,0,0,1 },
        {1,0,0,0,0,0,0,0,0,3, 0,1,1,0,0,0,0,1,1,1, 0,0,1,1,1,1,1,0,0,0, 0,0,0,0,0,0,0,0,2,1 },
        {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,3,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,1,1,1,1 },
        {1,0,0,0,0,1,1,0,0,0, 0,0,0,0,1,1,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,1,1,1,1,1 },
        {1,0,0,3,1,1,1,0,0,0, 3,0,0,1,1,1,1,1,0,0, 0,0,0,0,0,0,0,0,1,1, 0,0,0,0,1,1,1,1,1,1 },
        {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1 }
    };

    // Start is called before the first frame update
    void Start()
    {
        // フルHD
        Screen.SetResolution(1920, 1080, false);


        Vector3 position;
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                position = new Vector3(x - 1, -y + map.GetLength(0));
                if (map[y, x] == 1)
                {
                    Instantiate(block, position, Quaternion.identity);
                }
                else if (map[y, x] == 2)
                {
                    goal.transform.position = position;
                }
                else if (map[y, x] == 3)
                {
                    Instantiate(coin, position, Quaternion.identity);
                }
                position.z += 1.0f;
                Instantiate(block, position, Quaternion.identity);
            }
        }

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalScript.isGameClear)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        scoreText.text = "Score : " + score;
    }
}
