using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    public List<Monster> monsters;
    public List<Canvas> canvasParent;
    [SerializeField] public Image Left;
    [SerializeField] public Image Down;
    [SerializeField] public Image Upper;
    [SerializeField] public Image Right;
}
