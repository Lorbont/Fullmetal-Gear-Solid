using UnityEngine;

public class PlayerSwipeMovement : MonoBehaviour
{
    public float ForceValue;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        SwipeDetection.SwipeEvent += OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    {
        Move(direction);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Move(Vector3.left);
        else if (Input.GetKeyDown(KeyCode.D))
            Move(Vector3.right);
        else if (Input.GetKeyDown(KeyCode.W))
            Move(Vector3.forward);
        else if (Input.GetKeyDown(KeyCode.S))
            Move(Vector3.back);

    }

    private void Move(Vector3 direction)
    {
       rb.AddRelativeForce(direction * ForceValue);
        // transform.Translate(direction * Time.deltaTime);// ''n ,htl lkz ghjdthrb
    }

}
