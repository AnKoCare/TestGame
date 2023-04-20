using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionManager : MonoBehaviour
{
    int j_1 = 0;
    int j_2 = 0;
    int j_3 = 0;
    int j_4 = 0;

    private void Start()
    {
        CreateDirection();
    }

    private void Update() 
    {
        CheckDirObj();
    }

    public void CheckDirObj()
    {
        for(int i = 0; i < LevelManager.Ins.monsters.Count; i ++)
        {
            if(LevelManager.Ins.monsters[i].imageDir.Count < LevelManager.Ins.monsters[i].SumDir)
            {
                switch (i)
                {
                    case 0:
                    {
                        DeActiveDir(0,j_1);
                        j_1++;
                        LevelManager.Ins.monsters[i].SumDir -= 1;
                        break;
                    }
                    case 1:
                    {
                        DeActiveDir(1,j_2);
                        j_2++;
                        LevelManager.Ins.monsters[i].SumDir -= 1;
                        break;
                    }
                    case 2:
                    {
                        DeActiveDir(2,j_3);
                        j_3++;
                        LevelManager.Ins.monsters[i].SumDir -= 1;
                        break;
                    }
                    case 3:
                    {
                        DeActiveDir(3,j_4);
                        j_4++;
                        LevelManager.Ins.monsters[i].SumDir -= 1;
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
                continue;
            }

        }
    }

    public void DeActiveDir(int i, int j)
    {
        GameObject obj = GameObject.Find("i = " + i + " j = " + j);
        obj.gameObject.SetActive(false);
    }


    public void CreateDirection()
    {
        for (int i = 0; i < LevelManager.Ins.monsters.Count; i++)
        {
            int PosDir = 1;
            for (int j = 0; j < LevelManager.Ins.monsters[i].directions.Count; j++)
            {
                if (LevelManager.Ins.monsters[i].directions[j] == Direction.Left)
                {
                    Image left = Instantiate(LevelManager.Ins.Left);
                    left.transform.SetParent(LevelManager.Ins.canvasParent[i].transform);
                    left.transform.position = new Vector2(LevelManager.Ins.canvasParent[i].transform.position.x - 1.5f + 0.6f * PosDir, LevelManager.Ins.canvasParent[i].transform.position.y);
                    PosDir++;
                    left.transform.localScale = new Vector3(0.8f, 0.4f, 1);
                    left.gameObject.name = "i = " + i + " j = " + j;
                    LevelManager.Ins.monsters[i].imageDir.Add(left);
                    continue;
                }
                if (LevelManager.Ins.monsters[i].directions[j] == Direction.Right)
                {
                    Image right = Instantiate(LevelManager.Ins.Right);
                    right.transform.SetParent(LevelManager.Ins.canvasParent[i].transform);
                    right.transform.position = new Vector2(LevelManager.Ins.canvasParent[i].transform.position.x - 1.5f + 0.6f * PosDir, LevelManager.Ins.canvasParent[i].transform.position.y);
                    PosDir++;
                    right.transform.localScale = new Vector3(0.8f, 0.4f, 1);
                    right.gameObject.name = "i = " + i + " j = " + j;
                    LevelManager.Ins.monsters[i].imageDir.Add(right);
                    continue;
                }
                if (LevelManager.Ins.monsters[i].directions[j] == Direction.Down)
                {
                    Image down = Instantiate(LevelManager.Ins.Down);
                    down.transform.SetParent(LevelManager.Ins.canvasParent[i].transform);
                    down.transform.position = new Vector2(LevelManager.Ins.canvasParent[i].transform.position.x - 1.5f + 0.6f * PosDir, LevelManager.Ins.canvasParent[i].transform.position.y);
                    PosDir++;
                    down.transform.localScale = new Vector3(0.4f, 0.8f, 1);
                    down.gameObject.name = "i = " + i + " j = " + j;
                    LevelManager.Ins.monsters[i].imageDir.Add(down);
                    continue;
                }
                if (LevelManager.Ins.monsters[i].directions[j] == Direction.Upper)
                {
                    Image upper = Instantiate(LevelManager.Ins.Upper);
                    upper.transform.SetParent(LevelManager.Ins.canvasParent[i].transform);
                    upper.transform.position = new Vector2(LevelManager.Ins.canvasParent[i].transform.position.x - 1.5f + 0.6f * PosDir, LevelManager.Ins.canvasParent[i].transform.position.y);
                    PosDir++;
                    upper.transform.localScale = new Vector3(0.4f, 0.8f, 1);
                    upper.gameObject.name = "i = " + i + " j = " + j;
                    LevelManager.Ins.monsters[i].imageDir.Add(upper);
                    continue;
                }
            }
        }
    }
}
