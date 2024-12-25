using UnityEngine;

public class Fliper : MonoBehaviour
{
    private bool _isLastOrientationRight = true;

    public void Flip(float direction)
    {
        bool isCurrentOrientationRight = direction > 0;
        float flipBound = 0.05f;
        float rightOrientation = 0f;
        float leftOrientation = 180f;

        if (_isLastOrientationRight != isCurrentOrientationRight)
        {
            if (Mathf.Abs(direction) >= flipBound)
            {
                float rotationY = (direction > 0) ? rightOrientation : leftOrientation;
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, rotationY, transform.rotation.z));
                _isLastOrientationRight = !_isLastOrientationRight;
            }
        }
    }
}