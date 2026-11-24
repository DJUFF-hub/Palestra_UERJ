using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GrabDistance : MonoBehaviour, IXRSelectFilter
{
    [SerializeField] MedeDistancia medeDistancia;
    float dist;

    [SerializeField] [Range(0.1f, 5.0f)] private float distanciaMaxima = 1.5f;

    public bool canProcess => true;

    public bool Process(IXRSelectInteractor interactor, IXRSelectInteractable interactable)
    {
        dist = medeDistancia.Distancia;
        return dist <= distanciaMaxima;
    }
    
}
