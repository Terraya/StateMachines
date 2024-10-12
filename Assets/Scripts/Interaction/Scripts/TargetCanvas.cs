using Interaction.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class TargetCanvas : MonoBehaviour
{
    public Text TargetNameUI;
    public Slider HealthSlider;

    private void OnEnable()
    {
        Interactor.OnNewTarget += SetIdentity;
        Interactor.OnEmptyTarget += HideIdentity;
    }

    private void OnDisable()
    {
        Interactor.OnNewTarget -= SetIdentity;
        Interactor.OnEmptyTarget -= HideIdentity;
    }

    private void SetIdentity(IIdentity identity)
    {
        if (identity is ILivingIdentity livingIdentity)
        {
            HealthSlider.value = livingIdentity.GetHealth() / livingIdentity.GetMaxHealth();
            HealthSlider.gameObject.SetActive(true);
        }
        else
        {
            HealthSlider.gameObject.SetActive(false);
        }

        TargetNameUI.text = identity.GetIdentity();
        TargetNameUI.gameObject.SetActive(true);
    }

    private void HideIdentity()
    {
        TargetNameUI.gameObject.SetActive(false);
        HealthSlider.gameObject.SetActive(false);
    }
}