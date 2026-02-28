using UnityEngine;
public class PlayerInteractor : MonoBehaviour
{
    [Header("Pengaturan Interaksi")]
    [Tooltip("Titik tengah mata/kamera Sugeng")]
    [SerializeField] private Transform kepalaSugeng; 
    [Tooltip("Jarak maksimal tangan Sugeng bisa meraih barang (misal: 2 meter)")]
    [SerializeField] private float jarakInteraksi = 2f; 
    [Tooltip("KTP khusus untuk barang-barang yang bisa diambil/dipakai")]
    [SerializeField] private LayerMask layerBarang;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CobaAmbilBarang();
        }
    }
    private void CobaAmbilBarang()
    {
        if (Physics.Raycast(kepalaSugeng.position, kepalaSugeng.forward, out RaycastHit hit, jarakInteraksi, layerBarang))
        {
            Debug.Log("Sugeng melihat dan menekan E pada: " + hit.collider.gameObject.name);
        }
    }
}
