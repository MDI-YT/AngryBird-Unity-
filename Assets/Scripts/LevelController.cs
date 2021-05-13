using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public string _nextLevelName;
    Monster[] _monsters;

    void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();

    }
    // Update is called once per frame
    void Update()

    {
        if(MonsterAllDead())
        GoToNextLevel();
    }

    void GoToNextLevel()
    {
        Debug.Log("GoToNextLevel" + _nextLevelName);
    }

    bool MonsterAllDead()
    {
        foreach (var monster in _monsters)
        {
            if(monster.gameObject.activeSelf){
                return false;
            }
        }
        return true;
    }
}
