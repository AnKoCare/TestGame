using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Character : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] public Canvas canvasParent;

    public float hp;
    
    protected virtual void Start()
    {
        OnInit();

    }

    public virtual void OnInit()
    {
        hp = 100;
        healthBar.OnInit(100);
    }

    public void OnHit(float damege)
    {
        hp -= damege;
        if (hp <= 0) {
            hp = 0;
            Monster mons = gameObject.GetComponent<Monster>();
            //LevelManager.Ins.monsters.Remove(mons);
            Invoke("DeActiveCharacter", 1f);
        }
        healthBar.SetNewHp(hp);
    }

    public void DeActiveCharacter()
    {
        gameObject.SetActive(false);
        
    }
}
