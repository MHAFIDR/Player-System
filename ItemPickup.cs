using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [Header("Pengaturan Item")]
    [Tooltip("Nama barang ini (contoh: Sapu Lidi)")]
    public string namaBarang = "Sapu Lidi";

    [Tooltip("Tarik objek 3D sapu yang ada di bawah Main Camera (Tangan Sugeng) ke sini")]
    [SerializeField] private GameObject objekDiTangan;

    public void Ambil()
    {
        Debug.Log("Sugeng berhasil memungut: " + namaBarang);

        if (objekDiTangan != null)
        {
            objekDiTangan.SetActive(true);
        }

        Destroy(gameObject);
    }
}
