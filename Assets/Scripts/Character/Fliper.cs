using UnityEngine;

public class Fliper : MonoBehaviour
{
    public void Flip(float direction)
    {
        float flipBound = 0.05f;
        float rightOrientation = 0f;
        float leftOrientation = 180f;

        if (Mathf.Abs(direction) >= flipBound)
        {
            float rotationY = (direction > 0) ? rightOrientation : leftOrientation;

            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, rotationY, transform.rotation.z));
        }
    }
}