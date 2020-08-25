using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{   
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minPaddleXUnits = 1.5f;
    [SerializeField] float maxPaddleXUnits = 14.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXUnitsPos = Input.mousePosition.x / Screen.width * screenWidthUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mouseXUnitsPos, minPaddleXUnits, maxPaddleXUnits);
        transform.position = paddlePos;
    }
}
