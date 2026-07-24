using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 3f;
    public float minX = -8f;
    public float maxX = 8f;

    private int direction = 1; // 1 = kanan, -1 = kiri

    void Update()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        if (transform.position.x >= maxX)
        {
            direction = -1;
        }
        else if (transform.position.x <= minX)
        {
            direction = 1;
        }
    }
}
