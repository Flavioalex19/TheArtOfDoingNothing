using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{

    public List<GameObject> obj_TaskList = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            obj_TaskList.Add(obj);
        }
    }
}
