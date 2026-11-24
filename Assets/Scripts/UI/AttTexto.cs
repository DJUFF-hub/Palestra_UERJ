using UnityEngine;

public class AttTexto : MonoBehaviour
{

    public MedeDistancia medeDistancia;

    [SerializeField] private TMPro.TMP_Text texto;

    public void AtualizaTexto()
    {
        float distancia = medeDistancia.Distancia;
        texto.text = "Distancia: " + distancia.ToString("F2");
    }
}
