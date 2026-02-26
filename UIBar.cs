using UnityEngine;
using UnityEngine.UI;
public class UI_HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image healthBarImage;
    private void OnEnable()
    {
        playerHealth.OnHealthChanged += UpdateBarDarah;
    }
    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= UpdateBarDarah;
    }
    private void UpdateBarDarah(int sisaDarah)
    {
        float persentase = (float)sisaDarah / (float)playerHealth.MaxHealth;
        healthBarImage.fillAmount = persentase;
    }
}
