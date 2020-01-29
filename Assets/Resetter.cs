using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour
{
    
    private Rigidbody2D projectile;

    public Rigidbody2D[] projectiles;
    public float resetSpeed = 0.1f;

    private SpringJoint2D spring;
    private float resetSpeedSqr;

    private int counter = 0;
    private int maxcounter;

    private void Start()
    {
        maxcounter = projectiles.Length;

        projectile = projectiles[counter];
        //tu
       
        resetSpeedSqr = resetSpeed * resetSpeed;
        spring = projectile.GetComponent<SpringJoint2D>();
        
    }

    private void Update()
    {
        if (projectile.velocity.sqrMagnitude < resetSpeedSqr && spring == null)
        {
            
            Debug.Log("test");
            if (counter > maxcounter)
            {
                Reset();
            }
            else
            {
                if (counter <= maxcounter)
                {
                    Debug.Log("counter: " + counter);
                    //projectile.gameObject.SetActive(false);
                    //test wyłączenia game component
                    projectile.GetComponent<ProjectileDragging>().enabled = false;
                    counter++;
                    projectiles[counter].gameObject.SetActive(true);
                    Start();
                }
                else
                {
                    Reset();
                }
                
                /*projectile2.gameObject.SetActive(true);
                projectile.gameObject.SetActive(false);
                projectile = projectile2;

                counter++;
                Start();*/
                
            }
            
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() == projectile)
        {
            if (counter > maxcounter)
            {
                Reset();
            }
            else
            {
                if (counter <= maxcounter)
                {
                    Debug.Log("counter2: " + counter);
                    projectile.gameObject.SetActive(false);
                    counter++;
                    projectiles[counter].gameObject.SetActive(true);
                    Start();
                }
                else
                {
                    Reset();
                }

                /*projectile2.gameObject.SetActive(true);
                projectile.gameObject.SetActive(false);
                projectile = projectile2;

                counter++;
                Start();*/

            }
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene("Level01");
    }
}
