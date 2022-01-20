using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeLength : MonoBehaviour
{
    public TextMesh Text;
    public int FoodEaten = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "" + FoodEaten;

    }


}
