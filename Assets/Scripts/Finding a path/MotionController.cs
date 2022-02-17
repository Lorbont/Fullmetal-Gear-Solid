using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour
{
    
    private List<Vector2> PathTreger = new List<Vector2>();
    private List<Vector2> RandomPath = new List<Vector2>();
    private List<Vector2> CurrentPath = new List<Vector2>();
    private PathFinder PathFinder;
    private bool isMoving;
    private bool SeeTarget;

    public GameObject Treger;
   // public GameObject DeathEffect;
    public float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (Treger != null)
        {
            PathFinder = GetComponent<PathFinder>();
            ReCalculatePath();
            isMoving = true;

        }
    }

    public void ReCalculatePath()
    {
        PathTreger = PathFinder.GetPath(Treger.transform.position);

        if (PathTreger.Count == 0)
        {
            SeeTarget = false;
            if (!SeeTarget)
            {
                var r = Random.Range(0, PathFinder.FreeNodes.Count);
                RandomPath = PathFinder.GetPath(PathFinder.FreeNodes[r].Position);
                CurrentPath = RandomPath;
                print(CurrentPath.Count);
            }

        }
        else
        {
            CurrentPath = PathTreger;
            SeeTarget = true;
        }
    }

  
    void Update()
    {
        if (Treger == null) return;

        if (CurrentPath.Count == 0 && Vector2.Distance(transform.position, Treger.transform.position) > 0.5f)
        {
            ReCalculatePath();
            isMoving = true;
        }
        if (CurrentPath.Count == 0)
        {
            return;
        }


        if (isMoving)
        {
            if (Vector2.Distance(transform.position, CurrentPath[CurrentPath.Count - 1]) > 0.1f)
            {

                transform.position = Vector2.MoveTowards(transform.position, CurrentPath[CurrentPath.Count - 1], MoveSpeed * Time.deltaTime);

            }
            if (Vector2.Distance(transform.position, CurrentPath[CurrentPath.Count - 1]) <= 0.1f)
            {
                isMoving = false;
            }
        }
        else
        {

            ReCalculatePath();
            isMoving = true;
        }
    }
}