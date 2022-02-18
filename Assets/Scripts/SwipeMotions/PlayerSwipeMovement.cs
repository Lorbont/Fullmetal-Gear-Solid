using UnityEngine;

public class PlayerSwipeMovement : MonoBehaviour
{
    //public float ForceValue;

    //private Rigidbody2D rb;

    void Start()
    {
       // rb = GetComponent<Rigidbody2D>();

        SwipeDetection.SwipeEvent += OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    {
       
        Move(direction);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Move(Vector2.left);                         // Vector3
        else if (Input.GetKeyDown(KeyCode.D))
            Move(Vector2.right);
        else if (Input.GetKeyDown(KeyCode.W))
            Move(Vector2.up);
        else if (Input.GetKeyDown(KeyCode.S))
            Move(Vector2.down);

    }

    private void Move(Vector2 direction)
    {
      //  Debug.Log("e");
        //rb.AddRelativeForce(direction * ForceValue);
        transform.Translate(direction);
    }

}
