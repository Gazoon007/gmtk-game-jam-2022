using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Enemy;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemySpawnerData _enemySpawnerData;

    private void Start()
    {
        var startPosition = new Vector3(transform.position.x + 100f, transform.position.y, transform.position.z);
        var nextPosition = startPosition;

        var tempArr = new List<GameObject>();
        
        for (int i = 0; i < _enemySpawnerData.Enemies.Length; i++)
        {
            for (int j = 0; j < _enemySpawnerData.Enemies[i].Qty; j++)
            {
                tempArr.Add(_enemySpawnerData.Enemies[i].Enemy);
            }
        }

        for (int i = 0; i < _enemySpawnerData.percentageOfEmptyGapProbability / 10; i++)
        {
            tempArr.Add(null);
        }
        
        
        var shuffledArr = tempArr.OrderBy(a => Guid.NewGuid()).ToList();

        foreach (var enemy in shuffledArr)
        {
            if (enemy != null)
            {
                Instantiate(enemy, nextPosition, Quaternion.identity);
            }
            nextPosition.x += 20f;
        }
        
    }
}
