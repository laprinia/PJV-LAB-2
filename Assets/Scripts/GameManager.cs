using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{   public int golemInstances=3;
    public GameObject GolemPrefab;
    private void Start()
    {
        for (int i = 0; i < golemInstances; i++)
        {
            GameObject go=Instantiate(GolemPrefab, new Vector3(Random.Range(0f, 90f), 12.1f, 0f),Quaternion.identity);
            go.tag = "Golem";
            go.SetActive(true);
        }
        
    }
}
