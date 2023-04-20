using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSight : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Controller controller;
    [SerializeField] public bool isInSight = false;


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Monster"))
        {
            player.isMonster = true;
            isInSight = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Monster"))
        {
            Monster monster = other.gameObject.GetComponent<Monster>();
            AttackMonster(monster);
        }    
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Monster"))
        {
            Monster monster = other.gameObject.GetComponent<Monster>();
            player.isMonster = false;
            isInSight = false;
        }    
    }

    private void AttackMonster(Monster monsters)
    {
        if(monsters.directions.Count == 0)
        {
            return;
        }
        if(controller.isSlideUpper && monsters.directions[0] == Direction.Upper)
        {
            monsters.directions.RemoveAt(0);
            monsters.imageDir.RemoveAt(0);
            monsters.OnHit(25);
            controller.isSlideUpper = false;
            return;
        }
        if(controller.isSlideDown && monsters.directions[0] == Direction.Down)
        {
            monsters.directions.RemoveAt(0);
            monsters.imageDir.RemoveAt(0);
            monsters.OnHit(25);
            controller.isSlideDown = false;
            return;
        }
        if(controller.isSlideLeft && monsters.directions[0] == Direction.Left)
        {
            monsters.directions.RemoveAt(0);
            monsters.imageDir.RemoveAt(0);
            monsters.OnHit(25);
            controller.isSlideLeft = false;
            return;
        }
        if(controller.isSlideRight && monsters.directions[0] == Direction.Right)
        {
            monsters.directions.RemoveAt(0);
            monsters.imageDir.RemoveAt(0);
            monsters.OnHit(25);
            controller.isSlideRight = false;
            return;
        }
        controller.isSlideDown = false;
        controller.isSlideLeft = false;
        controller.isSlideRight = false;
        controller.isSlideUpper = false;
    }
}
