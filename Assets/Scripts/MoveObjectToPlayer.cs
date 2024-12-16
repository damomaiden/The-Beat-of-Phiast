using UnityEngine;

public class MoveObjectStraight : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f; // Speed of movement in a straight line

    private void Update()
    {
        // Move the object backward along its local Z-axis (towards the player)
        transform.position += -transform.forward * moveSpeed * Time.deltaTime;
    }
}
