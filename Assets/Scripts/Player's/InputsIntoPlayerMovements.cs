using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerShootManager))]
public class InputsIntoPlayerMovements : MonoBehaviour
{
    [SerializeField] float moveFactor = 3f;
    Rigidbody2D m_rigid;
    PlayerShootManager m_shootManager;

    bool inputsEnabled = true;
    private void Start()
    {
        m_rigid = GetComponent<Rigidbody2D>();
        m_shootManager = GetComponent<PlayerShootManager>();
    }
    public void Move(float horizontalInput, bool shootInput)
    {
        if (!inputsEnabled) return;

        m_rigid.velocity = new Vector2(horizontalInput * moveFactor, 0);
        if (shootInput)
        {
            m_shootManager.Shoot();
        }
    }

    public void DisableInputs()
    {
        inputsEnabled = false;
    }

    public void EnableInputs()
    {
        inputsEnabled = true;
    }
}
