using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] //Dxa a gente colocar o Script pelo Editor
    PlayerInput playerInput;

    [Range(0f,10f)] //Mostra o Slider no Editor
    public float sensi = 5f;

    private Camera cam;
    private Vector2 lookValue;
    private float giracam = 0f;


    void Start()
    {
        if (playerInput == null)
        {
            playerInput = GetComponent<PlayerInput>();
        }
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        lookValue = playerInput.look;
        if (lookValue.sqrMagnitude > 0.01f)
        {
            RotateCamera();
        }
        
    }

    void RotateCamera()
    {
        float mouseX = lookValue.x * sensi * Time.deltaTime;
        float mouseY = lookValue.y * sensi * Time.deltaTime;

        giracam -= mouseY;
        giracam = Mathf.Clamp(giracam, -90f, 90f); 

        // Rotaciona o jogador horizontalmente
        transform.Rotate(Vector3.up * mouseX);

        // Rotaciona a câmera verticalmente
        cam.transform.localRotation = Quaternion.Euler(giracam, 0, 0);
    }


}
