using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{

    public List<GameObject> obj_TaskInteractableList = new List<GameObject>();//List of interactable objects

    private void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            obj_TaskInteractableList.Add(obj);
        }
    }
}
