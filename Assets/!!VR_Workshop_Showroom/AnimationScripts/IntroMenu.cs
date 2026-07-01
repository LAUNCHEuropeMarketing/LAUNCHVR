using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IntroMenu : MonoBehaviour
{
    public GameObject menu;

    private XRSimpleInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnPressed);
    }

    private void OnPressed(SelectEnterEventArgs args)
    {
        menu.SetActive(false);
    }

    private void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnPressed);
    }
}
