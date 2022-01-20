using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private GameObject Snake_Length;
    public SnakeLength componentSnakeLength;
    public SnakeMovementNew componentSnakeTail1;
    private GameObject Snake;
    public int food = 1;

    void Start()
    {
        //componentSnakeLength = GetComponent<SnakeLength>();
        //componentSnakeTail1 = GetComponent<SnakeMovementNew>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Snake_Head")
        {
            /*            Snake_Length = GameObject.Find("Snake_Length");
                        SnakeLength sn = Snake_Length.GetComponent<SnakeLength>();

                        sn.FoodEaten++;*/
            //componentSnakeLength.FoodEaten++;
            componentSnakeLength.FoodEaten += food;
            componentSnakeTail1.AddBody();


            Debug.Log("Collided with food!");
            Destroy(this.gameObject);
            //componentSnakeTail1.AddBody();
        }
    }
}
