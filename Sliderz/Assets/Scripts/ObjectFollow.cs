using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{

    public Transform obj;
    public Vector2 offset;
    public float speed = 2f;
    public bool smoothnessBool = false;

    void FixedUpdate()
    {
        float smoothness = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        if (smoothnessBool)
        {
            position.y = Mathf.Max(Mathf.Lerp(this.transform.position.y, obj.position.y, smoothness), -1) + offset.y;
            position.x = Mathf.Lerp(this.transform.position.x, obj.position.x, smoothness) + offset.x;
        }
        else if (!smoothnessBool)
        {
            position.y = GetComponent<LvlGenerator>().bottomY + offset.y;
            position.x = obj.position.x + offset.x;
        }
        this.transform.position = position;
    }
}
