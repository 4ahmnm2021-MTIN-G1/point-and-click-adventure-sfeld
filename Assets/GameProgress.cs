using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress: MonoBehaviour
{
    public static GameProgress gameProgress;
    public Condition[] conditions;

    private void Start()
    {
        gameProgress = this;
    }
}
