using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction { Left, Right, Down, Upper }
public class Monster : Character
{
    [SerializeField] public int SumDir;
    public List<Direction> directions; 
    public List<Image> imageDir;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] public Animator animator;
    

    private void Awake()
    {
        //SumDir = Random.Range(1,4);
        
        directions = new List<Direction>(SumDir);
        imageDir = new List<Image>(SumDir);
        CreateDirection();
    }

    private void Update() 
    {
        MoveMonster();
    }

    private void MoveMonster()
    {
        Vector2 position = transform.position; // vị trí hiện tại của đối tượng
        Vector2 targetPosition = target.position; // vị trí đích của đối tượng
        float step = speed * Time.deltaTime; // khoảng cách cần di chuyển trong khung hình hiện tại

        transform.position = Vector2.MoveTowards(position, targetPosition, step); // di chuyển đối tượng đến vị trí đích
    }

    public virtual void CreateDirection()
    {
        for (int i = 0; i < SumDir; i++)
        {
            int randomDir = Random.Range(0, 4);
            directions.Add((Direction)randomDir);
        }
    }

}
