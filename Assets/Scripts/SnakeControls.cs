using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControls : MonoBehaviour
{

    public float ForwardSpeed = 1.0f;
    public float Sensitivity = 10;
    private Vector3 _previousMousePosition;
    private SnakeMovementNew componentSnakeTail;
    private SnakeLength componentSnakeLength;

    public int Length = 1;


    // Start is called before the first frame update
    void Start()
    {
        componentSnakeTail = GetComponent<SnakeMovementNew>();
        componentSnakeLength = GetComponent<SnakeLength>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-ForwardSpeed * Time.deltaTime, 0, 0);

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            transform.position += new Vector3(0, 0, delta.x * Sensitivity);
            
        }

        _previousMousePosition = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.A))
        {
            Length++;
            componentSnakeTail.AddBody();
            //componentSnakeLength.FoodEaten++;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Length--;
            componentSnakeTail.RemoveBody();
            //componentSnakeLength.FoodEaten--;
        }


    }
}
