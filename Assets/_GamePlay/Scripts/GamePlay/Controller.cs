using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class Controller : MonoBehaviour
{
    [SerializeField] private Vector3 startInput;
    [SerializeField] private Vector3 endInput;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float threshold = 5f;
    [SerializeField] private bool isDraw = false;
    [SerializeField] private Animator animator;
    [SerializeField] public bool isSlideUpper = false;
    [SerializeField] public bool isSlideDown = false;
    [SerializeField] public bool isSlideRight = false;
    [SerializeField] public bool isSlideLeft = false;
    [SerializeField] private MainSight mainSight;


    

    private void Update() 
    {
        GetInPut();
        MoveToTarget();
        moveDirection = Vector3.zero;
        if(!mainSight.isInSight)
        {
            isSlideUpper = false;
            isSlideDown = false;
            isSlideLeft = false;
            isSlideRight = false;
        }
    }

    private void GetInPut()
    {
        if(isDraw == true)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startInput = Input.mousePosition;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            endInput = Input.mousePosition;
            if(Vector3.Distance(startInput, endInput) > threshold)
            {
                moveDirection = endInput - startInput;
            }
        }
    }

    public void MoveToTarget()
    {   
        if(moveDirection == Vector3.zero)
        {
            isDraw = false;
            return;
        }

        isDraw = true;

        if((Vector3.Angle(Vector3.up, moveDirection) <= 45f))
        {
            animator.SetTrigger("slideUp");

            isSlideUpper = true;
            moveDirection = Vector3.zero;
            isDraw = false;
            return;
        }
        if((Vector3.Angle(new Vector3(0,-1,0), moveDirection) <= 45f ))
        {
            animator.SetTrigger("slideDown");
            isSlideDown = true;
            moveDirection = Vector3.zero;
            isDraw = false;
            return;
        }
        if((Vector3.Angle(new Vector3(-1,0,0), moveDirection) <= 45f))
        {
            animator.SetTrigger("slideHorizontal");
            isSlideLeft = true;

            moveDirection = Vector3.zero;
            isDraw = false;
            return;
        }
        if((Vector3.Angle(new Vector3(1,0,0), moveDirection) <= 45f))
        {
            animator.SetTrigger("slideHorizontal");
            isSlideRight = true;
            moveDirection = Vector3.zero;
            isDraw = false;
            return;
        }
    }

    
}
