using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovementNew : MonoBehaviour
{
    public Transform SnakeHead;
    public Transform SnakeBody;
    public float bodyDiameter;

    private List<Transform> snakeBodies = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    private void Awake()
    {
        positions.Add(SnakeBody.position);        
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (SnakeHead.position - positions[0]).magnitude;

        if (distance > bodyDiameter)
        {
            Vector3 direction = (SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * bodyDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= bodyDiameter;
        }

        for (int i = 0; i < snakeBodies.Count; i++)
        {
            snakeBodies[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / bodyDiameter);

        }
    }

    public void AddBody()
    {
        Transform body = Instantiate(SnakeBody, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeBodies.Add(body);
        positions.Add(body.position);
    }

    public void RemoveBody()
    {
        Destroy(snakeBodies[0].gameObject);
        snakeBodies.RemoveAt(0);
        positions.RemoveAt(1);
    }
}
