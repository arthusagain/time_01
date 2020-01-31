using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    public float camSpeed = 1;
    public Vector3 offset;

    private void Update()
    {
        transform.position = player.position + offset;
    }
}
