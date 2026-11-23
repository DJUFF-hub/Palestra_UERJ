using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] //dxa eu colocar algo direto pelo editor
    private InputActionAsset _mapa;

    public InputActionAsset Mapa => _mapa;//n tem pq colocar um setter

    private InputActionMap _playerMap;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _escAction;

    private InputAction _lookAction;

    public Vector2 movement => _moveAction.ReadValue<Vector2>();
    public Vector2 look => _lookAction.ReadValue<Vector2>();
    public bool jump => _jumpAction.WasPressedThisFrame();

    void OnEnable() //Delimita qual mapa vai ser usado assim que o jogo começar
    {
        EnablePlayerInput();
    }

    void OnDisable()
    {
        DisableAllInputs();
    }

    public void EnablePlayerInput()
    {
        _playerMap = _mapa.FindActionMap("Player");
        _moveAction = _playerMap.FindAction("Andar");
        _jumpAction = _playerMap.FindAction("Pular");
        _escAction = _playerMap.FindAction("Esc");
        _lookAction = _playerMap.FindAction("Olhar");
        _escAction.performed += AbreMenu;
        _playerMap.Enable();
    } 

    private void DisableAllInputs()
    {
        _escAction.performed -= AbreMenu;
        foreach (var actionMap in _mapa.actionMaps)
        {
            actionMap.Disable();
        }
    }

    void AbreMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
        
    }

}
