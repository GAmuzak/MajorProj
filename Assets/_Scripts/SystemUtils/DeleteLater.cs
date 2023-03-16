using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private float initLength;
    [SerializeField] private Transform bodyUnitPrefab;
    [SerializeField] private Transform snakeBodyContainer;
    [SerializeField] private float speed;
    [SerializeField] private float moveDistance;

    private Vector3 moveDirection;
    private List<Transform> body = new List<Transform>();

    private void Awake()
    {
        for(int i=1; i<=initLength;i++)
        {
            Transform newSnakeUnit = Instantiate(bodyUnitPrefab, snakeBodyContainer);
            newSnakeUnit.position = Vector3.up*i;
            body.Add(newSnakeUnit);
        }
        
        InvokeRepeating(nameof(MoveSnake), 1f, 1f/speed);
    }

    private void MoveSnake()
    {
        UpdateBodyUnits();
        transform.position = moveDirection * moveDistance;
    }
    
    private void UpdateBodyUnits()
    {
        body[0].position = transform.position;
        for (int i = body.Count-1; i >= 1; i--)
        {
            body[i].position = body[i-1].position;
        }
    }
}
