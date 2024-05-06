using DG.Tweening;
using System;
using UnityEngine;

public class charaster : MonoBehaviour
{
    public Action WallTriger;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<WallTag>() != null)
        {
            WallTriger?.Invoke();
        }
    }

    [SerializeField] private float forwardspeed;
    [SerializeField] private float sidespeed;
    [SerializeField] private float highForce;
    [SerializeField] private float canJumpAboveThisJumpHeightPercentage;
    [SerializeField] private float AnimationTime;
    public СScreaptLose wall;

    private void Update()
    {
        float sideDirection = 0;
        Scale();

        if (Input.GetKey(KeyCode.D))
        {
            sideDirection = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            sideDirection = -1;
        }

        float Jump = 0;

        if (Input.GetKeyDown(KeyCode.W))
        {
            float canJumpYPosition = NumberCalculator.FindPercentage(highForce, canJumpAboveThisJumpHeightPercentage);

            if (transform.position.y < canJumpYPosition)
            {
                Jump = highForce;
            }
        }

        transform.position = GetNextPosition(sideDirection, Jump);
    }

    private Vector3 GetNextPosition(float sideDirection, float jumphigh)
    {

        Vector3 newPosition = new Vector3();

        newPosition.x = transform.position.x + (sideDirection * sidespeed);
        newPosition.y = transform.position.y + jumphigh;
        newPosition.z = transform.position.z + forwardspeed;

        return newPosition;
    }

    private void Scale()
    {
        Vector3 scale = transform.localScale;
        if (Input.GetKeyUp(KeyCode.Alpha1))

        {
            transform.DOScale(Vector3.one * 1, AnimationTime);
           /* scale.x = 1;
            scale.y = 1;
            scale.z = 1;*/

        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            transform.DOScale(new Vector3(2,2,2), AnimationTime);
            /* scale.x = 2;
             scale.y = 2;
             scale.z = 2;*/

        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            transform.DOScale(Vector3.one * 3, AnimationTime);
            

            /*scale.x = 3;
            scale.y = 3; 
            scale.z = 3;*/
        }

    }


    public void Freeze()
    {
        forwardspeed = 0;
        sidespeed = 0;
        highForce = 0;
    }

}

