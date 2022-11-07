using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static StackManager Instance { get; private set; }
    public List<Transform> stackedObjectsList = new List<Transform>();

    [SerializeField] private float xSpaceBetweenCups = 0.6f;
    [SerializeField] private float slideDuration = 0.2f;
    private void Awake()
    {
        SingletonCheck();
        stackedObjectsList.Add(transform.Find("CollectorVisual"));
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveListElements();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            MoveToOrigin();
        }
    }

    public void StackCup(Transform tf)
    {
        stackedObjectsList.Add(tf);
        tf.SetParent(transform);
        tf.localPosition = new Vector3(0, 0, (stackedObjectsList.Count - 1) * xSpaceBetweenCups);
    }

    private void MoveListElements()
    {
        for (int i = 1; i < stackedObjectsList.Count; i++)
        {
            stackedObjectsList[i].DOLocalMoveX(stackedObjectsList[i - 1].localPosition.x  ,slideDuration);
        }
    }

    private void MoveToOrigin()
    {
        for (var index = 1; index < stackedObjectsList.Count; index++)
        {
            stackedObjectsList[index].DOLocalMoveX(stackedObjectsList[0].localPosition.x, 0.7f);
        }
    }

    private void SingletonCheck()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}