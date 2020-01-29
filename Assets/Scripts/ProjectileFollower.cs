using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollower : MonoBehaviour
{
    public Transform projectile;
    public Transform[] projectiles;

    private int counter = 0;
    private int max;
    public Transform farLeft;
    public Transform farRight;

    private void Start()
    {
        projectile = projectiles[counter];
        max = projectiles.Length;
    }

    private void Update()
    {
        if (projectile.gameObject.active == true&&projectile.GetComponent<ProjectileDragging>().enabled==true)
        {
                Vector3 newPosition = transform.position;
                newPosition.x = projectile.position.x;
                newPosition.x = Mathf.Clamp(newPosition.x, farLeft.position.x, farRight.position.x);
                transform.position = newPosition;
        }
        else
        {
            if (counter <= max)
            {
                counter++;
                projectile = projectiles[counter];
            }
            
        }
        
    }


}
