using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Wave enemyWave;
    public bool finished;

    IEnumerator Start()
    {
        StartCoroutine("SpawnEnemies");

        yield break;

    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyWave.groups.Length; i++)
        {
            if (enemyWave.groups[i].enemyTypes.Length > 0)
            {
                Group group = enemyWave.groups[i];
                for (int j = 0; j < group.enemyTypes.Length; j++)
                {
                    Type type = group.enemyTypes[j];
                    Enemy newEnemy = Instantiate(type.enemy, type.spawnPoint.position + new Vector3(type.offsetX, type.offsetY, 0), Quaternion.identity).GetComponent<Enemy>();
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(type.moveX, type.moveY);
                    newEnemy.startVelocity = new Vector2(type.moveX, type.moveY);
                    yield return new WaitForSeconds(group.enemyTypes[j].cooldown); // cooldown between individual enemies

                }
            }


            yield return new WaitForSeconds(enemyWave.groups[i].cooldown); // cooldown between groups
        }

        Debug.Log("done with wave");
        finished = true;
        GameManager.master.CheckForEnemies();
    }

    [Serializable]
    public struct Type
    {
        public GameObject enemy;
        public Transform spawnPoint;
        public float offsetX;
        public float offsetY;
        public float moveX;
        public float moveY;
        public float cooldown;
    }

    [Serializable]
    public struct Group
    {
        public Type[] enemyTypes;
        public float cooldown;
    }

    [Serializable]
    public struct Wave
    {
        public Group[] groups;
    }
}
