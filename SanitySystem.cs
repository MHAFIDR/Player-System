```csharp
using UnityEngine;
using System;
public class SanitySystem : MonoBehaviour
{
    [Header("Pengaturan Kewarasan")]
    [SerializeField] private float maxSanity = 100f;
    [SerializeField] private float kecepatanGila = 15f;
    [SerializeField] private float kecepatanPulih = 5f;
    public float CurrentSanity { get; private set; }
    public event Action<float> OnSanityChanged; 
    [Header("Sensor Mata Sugeng")]
    [SerializeField] private Transform hantu;
    [SerializeField] private Transform kepalaSugeng;
    [SerializeField] private float jarakMaksimal = 15f;
    [SerializeField] private float sudutPandang = 70f;
    [SerializeField] private LayerMask layerHalangan;
    private void Start()
    {
        CurrentSanity = 0f;
        OnSanityChanged?.Invoke(CurrentSanity);
    }
    private void Update()
    {
        if (ApakahMelihatHantu())
        {
            TambahGila();
        }
        else
        {
            PulihWaras();
        }
    }
    private bool ApakahMelihatHantu()
    {
        if (hantu == null) return false;
        float jarakKeHantu = Vector3.Distance(kepalaSugeng.position, hantu.position);
        if (jarakKeHantu > jarakMaksimal) return false;
        Vector3 arahKeHantu = (hantu.position - kepalaSugeng.position).normalized;
        float sudut = Vector3.Angle(kepalaSugeng.forward, arahKeHantu);
        if (sudut > sudutPandang / 2f) return false;
        if (Physics.Raycast(kepalaSugeng.position, arahKeHantu, out RaycastHit hit, jarakKeHantu, layerHalangan))
        {
            return false;
        }
        return true; 
    }
    private void TambahGila()
    {
        CurrentSanity = Mathf.Min(CurrentSanity + (kecepatanGila * Time.deltaTime), maxSanity);
        OnSanityChanged?.Invoke(CurrentSanity);
    }
    private void PulihWaras()
    {
        if (CurrentSanity > 0)
        {
            CurrentSanity = Mathf.Max(CurrentSanity - (kecepatanPulih * Time.deltaTime), 0);
            OnSanityChanged?.Invoke(CurrentSanity);
        }
    }
}
```
