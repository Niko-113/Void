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
        StartCoroutine(SpawnEnemies(enemyWave.cooldown));

        yield break;

    }

    IEnumerator SpawnEnemies(float cooldownBetweenWaves)
    {
        for (int i = 0; i < enemyWave.groups.Length; i++)
        {
            if (enemyWave.groups[i].enemyTypes.Length > 0)
            {
                Group group = enemyWave.groups[i];
                for (int j = 0; j < group.enemyTypes.Length; j++)
                {
                    Enemy newEnemy = Instantiate(group.enemyTypes[j].enemy, group.spawnPoint.position + new Vector3(group.enemyTypes[j].offsetX, group.enemyTypes[j].offsetY, 0), Quaternion.identity).GetComponent<Enemy>();
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(group.moveX, group.moveY);
                    newEnemy.startVelocity = new Vector2(group.moveX, group.moveY);
                    yield return new WaitForSeconds(group.enemyTypes[j].cooldown);

                }
            }


            yield return new WaitForSeconds(cooldownBetweenWaves); // cooldown between groups
        }

        Debug.Log("done with wave");
        finished = true;
        GameManager.master.CheckForEnemies();
    }

    [Serializable]
    public struct Type
    {
        public GameObject enemy;
        public float offsetX;
        public float offsetY;
        public float cooldown;
    }

    [Serializable]
    public struct Group
    {
        public Type[] enemyTypes;
        public Transform spawnPoint;
        public float moveX;
        public float moveY;
    }

    [Serializable]
    public struct Wave
    {
        public Group[] groups;
        public float cooldown;
    }
}
