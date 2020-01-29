using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesDead : MonoBehaviour
{
    public Rigidbody2D[] enemies;

    private int counter;
    private int start;

    void Start()
    {
        start = 0;
        counter = enemies.Length;
    }
    // Update is called once per frame
    void Update()
    {
        start = 0;
        foreach (Rigidbody2D i in enemies)
        {
            if (i.gameObject.active == false)
            {
                start++;
            }
        }
        if (start == counter)
        {
            Invoke("NextLevel",4f);
        }
    }
    void NextLevel()
    {
        SceneManager.LoadScene("Level02");
    }
}
