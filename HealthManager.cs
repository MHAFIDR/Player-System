using System;
using UnityEngine;
public class Health : MonoBehaviour
{
    [Header("Pengaturan Darah")]
    [SerializeField] private int maxHealth = 100;
    public int CurrentHealth { get; private set; }
    public event Action<int> OnHealthChanged;
    public event Action OnDie;
    private void Start()
    {
        CurrentHealth = maxHealth;
        OnHealthChanged?.Invoke(CurrentHealth);
    }
    public void TakeDamage(int damageAmount)
    {
        if (CurrentHealth <= 0) return; 
        CurrentHealth = Mathf.Max(CurrentHealth - damageAmount, 0);
        OnHealthChanged?.Invoke(CurrentHealth);
        if (CurrentHealth == 0)
        {
            Die();
        }
    }
    public void Heal(int healAmount)
    {
        if (CurrentHealth <= 0) return;
        CurrentHealth = Mathf.Min(CurrentHealth + healAmount, maxHealth);
        OnHealthChanged?.Invoke(CurrentHealth);
    }
    private void Die()
    {
        OnDie?.Invoke();
    }
}
