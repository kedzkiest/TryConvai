using Unity.VisualScripting;
using UnityEngine;

public class JiggleMovement : MonoBehaviour
{
    /// <summary>
    /// The range of position jiggling in x coordinate
    /// </summary>
    [SerializeField] private float xJiggleRange;

    /// <summary>
    /// The range of position jiggling in y coordinate
    /// </summary>
    [SerializeField] private float yJiggleRange;

    /// <summary>
    /// The speed for jiggle movement
    /// </summary>
    [SerializeField] private float jiggleSpeed;

    /// <summary>
    /// The maximum x range for goal setting
    /// </summary>
    private float xSearchSpaceMax;

    /// <summary>
    /// The minimum x range for goal setting
    /// </summary>
    private float xSearchSpaceMin;

    /// <summary>
    /// The maximum y range for goal setting
    /// </summary>
    private float ySearchSpaceMax;

    /// <summary>
    /// The minimum y range for goal setting
    /// </summary>
    private float ySearchSpaceMin;

    /// <summary>
    /// The point where the gameobject that has this script wants to go
    /// </summary>
    private Vector3 goal;

    /// <summary>
    /// The flag for changing the goal
    /// </summary>
    private bool goNext = true;

    private void Start()
    {
        xSearchSpaceMax = transform.position.x + xJiggleRange;
        xSearchSpaceMin = transform.position.x - xJiggleRange;

        ySearchSpaceMax = transform.position.y + yJiggleRange;
        ySearchSpaceMin = transform.position.y - yJiggleRange;
    }

    // Update is called once per frame
    private void Update()
    {
        if (goNext)
        {
            goal = new Vector3(
            x: Random.Range(xSearchSpaceMin, xSearchSpaceMax),
            y: Random.Range(ySearchSpaceMin, ySearchSpaceMax),
            z: transform.position.z
            );
        }

        goNext = GoToPoint(goal);
    }

    private bool GoToPoint(Vector3 goal)
    {
        Vector3 direction = goal - transform.position;
        transform.position += direction.normalized * Time.deltaTime * jiggleSpeed;

        return Vector3.Distance(transform.position, goal) <= 0.05f;
    }
}
