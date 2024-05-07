using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CamControls : MonoBehaviour
{
    [SerializeField] float moveFactor = 5f;

    Rigidbody2D m_rigid;
    // Start is called before the first frame update
    void Start()
    {
        m_rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

        m_rigid.velocity = new Vector2(horiz, verti).normalized * moveFactor;
    }
}
