using UnityEngine;

public class Fliper : MonoBehaviour
{
    public void Flip(float direction)
    {
        Debug.Log("Вызван поворот");
        float flipBound = 0.05f;

        if (Mathf.Abs(direction) >= flipBound)
        {
            Debug.Log("Поворот повернут");
            transform.localScale = new Vector2(Mathf.Sign(direction), transform.localScale.y);
        }
    }
}
