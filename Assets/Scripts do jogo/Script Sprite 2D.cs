using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    public Sprite front;
    public Sprite side;
    public Sprite back;

    public Transform cam; // 👈 agora você define no Inspector

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (cam == null)
        {
            cam = Camera.main.transform;
        }
    }

    void Update()
    {
        if (cam == null) return;

        // Billboard
        Vector3 lookPos = cam.position;
        lookPos.y = transform.position.y;
        transform.LookAt(lookPos);

        // Direção
        Vector3 toCam = cam.position - transform.position;
        toCam.y = 0;
        toCam.Normalize();

        float dot = Vector3.Dot(Vector3.forward, toCam);
        float cross = Vector3.Cross(Vector3.forward, toCam).y;

        if (dot > 0.7f)
        {
            sr.sprite = front;
            sr.flipX = false;
        }
        else if (dot < -0.7f)
        {
            sr.sprite = back;
            sr.flipX = false;
        }
        else
        {
            sr.sprite = side;
            sr.flipX = (cross < 0);
        }
    }
}