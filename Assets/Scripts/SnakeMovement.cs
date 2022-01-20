using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public List<Transform> Bodies = new List<Transform>();
    public float minDistance = 0.25f;

    public int startingSize;

    public float speed = 1f;
    public float rotationSpeed = 40;
    public GameObject snakeBodyPrefab;
    public float Sensitivity = 10;
    private Vector3 _previousMousePosition;

    private float distance;
    private Transform currentBody;
    private Transform previousBody;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startingSize - 1; i++)
        {
            AddSnakeBody();

        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKey(KeyCode.Q))
        {
            AddSnakeBody();
        }
    }

    public void Move()
    {
        float currentSpeed = speed;

        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            transform.position += new Vector3(0, 0, delta.x * Sensitivity);

        }


        _previousMousePosition = Input.mousePosition;


        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed *= 2;
        }

        Bodies[0].Translate(Bodies[0].forward * currentSpeed * Time.smoothDeltaTime, Space.World);

        if (Input.GetAxis("Horizontal") != 0)
        {
            Bodies[0].Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));

        }

        for (int i = 1; i < Bodies.Count; i++)
        {
            currentBody = Bodies[i];
            previousBody = Bodies[i - 1];
            distance = Vector3.Distance(previousBody.position, currentBody.position);

            Vector3 newPosition = previousBody.position;
            newPosition.y = Bodies[0].position.y;

            float T = Time.deltaTime * distance / minDistance * currentSpeed;

            if (T > 0.5f)
            {
                T = 0.5f;
            }
            currentBody.position = Vector3.Slerp(currentBody.position, newPosition, T);
            currentBody.rotation = Quaternion.Slerp(currentBody.rotation, previousBody.rotation, T);
        }
    }

    public void AddSnakeBody()
    {
        Transform newBody = (Instantiate(snakeBodyPrefab, Bodies[Bodies.Count - 1].position, Bodies[Bodies.Count - 1].rotation) as GameObject).transform;

        newBody.SetParent(transform);
        Bodies.Add(newBody);
    }
}
