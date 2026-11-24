using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MedeDistancia : MonoBehaviour
{
    [SerializeField] private NearFarInteractor interactor; //o objeto q ta perto
    [SerializeField] private Transform Referencia; //o objeto q ta longe
    private float _distancia;

    void OnEnable()
    {
        interactor.hoverEntered.AddListener(OnHoverEntered);
    }

    void OnDisable()
    {
        interactor.hoverEntered.RemoveListener(OnHoverEntered);
    }


    public float Distancia
    {
        get => _distancia;
    }

    public float medeDistancia(Transform obj)
    {
        _distancia = Vector3.Distance(obj.position, Referencia.position);
        return _distancia;
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        GameObject objeto = args.interactableObject.transform.gameObject;
        medeDistancia(objeto.transform);
        Debug.Log("Apontando para: " + objeto.name);
    }

}
