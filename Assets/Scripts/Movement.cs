using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rB;
    public string rightKey = "D";

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rB.AddForceX(7);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rB.AddForceX(-7);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rB.AddForceY(25);
        }
    }

}
