using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 2f;
    public float range = 5f;
    public float waitTime = 2f;

    private Vector3 targetPosition;
    private float waitCounter;
    private bool isWaiting;

    void Start()
    {
        SetNewTarget();
    }

    void Update()
    {
        if (isWaiting)
        {
            waitCounter -= Time.deltaTime;

            if (waitCounter <= 0)
            {
                isWaiting = false;
                SetNewTarget();
            }
        }
        else
        {
            // Move em direção ao alvo
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Chegou no destino?
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isWaiting = true;
                waitCounter = waitTime;
            }
        }
    }

    void SetNewTarget()
    {
        float randomX = Random.Range(-range, range);
        float randomZ = Random.Range(-range, range);

        targetPosition = new Vector3(
            transform.position.x + randomX,
            transform.position.y,
            transform.position.z + randomZ
        );
    }
}