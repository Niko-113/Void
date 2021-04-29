using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditorInternal;

public class EnemyManager : MonoBehaviour
{
    public Wave enemyWave;
    

    [Serializable]
    public struct Type
    {
        public GameObject enemy;
        public int count;
        public float cooldown;
    }

    [Serializable]
    public struct Group
    {
        public Type[] enemyTypes;
    }

    [Serializable]
    public struct Wave
    {
        public Group[] groups;
        public float cooldown;
    }
}
