using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public Monster monster;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Player")
        {
            monster.animator.SetTrigger("attack");
            Character character = collision.gameObject.GetComponent<Character>();
            character.OnHit(10);
        }    
    }
}
