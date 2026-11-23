using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Movimento : MonoBehaviour
{

    [SerializeField] //Dxa a gente colocar o Script pelo Editor
    PlayerInput playerInput;

    [Range(0f,10f)] //Mostra o Slider no Editor
    public float velocidade = 5f;



    private CharacterController rb;
    private Vector2 movimentValue;

    void Start()
    {
        if (playerInput == null)
        {
            playerInput = GetComponent<PlayerInput>();
        }
        rb = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        movimentValue = playerInput.movement.normalized;
        Vector3 movimento = new Vector3(movimentValue.x, 0, movimentValue.y);
        
        rb.Move(transform.TransformDirection(movimento) * velocidade * Time.deltaTime);
    }
}
