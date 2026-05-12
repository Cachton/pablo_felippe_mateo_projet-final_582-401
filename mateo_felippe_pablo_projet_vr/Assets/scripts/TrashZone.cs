using System.Collections.Generic;
using UnityEngine;

public class TrashZone : MonoBehaviour
{
    public int trashCount = 0;
    public int limit = 5;

    // Son quand on jette la poubelle
    public AudioClip throwSound;

    // Liste de tous les sacs actifs
    public static List<GameObject> allTrash = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            // Joue le son quand la poubelle est jetée
            if (throwSound != null)
            {
                AudioSource.PlayClipAtPoint(throwSound, other.transform.position);
            }

            // Ajouter si pas déjà dans la liste
            if (!allTrash.Contains(other.gameObject))
            {
                allTrash.Add(other.gameObject);
            }

            trashCount++;

            // Supprime la poubelle
            Destroy(other.gameObject);

            // Reset si limite atteinte
            if (trashCount >= limit)
            {
                ClearAllTrash();
            }
        }
    }

    void ClearAllTrash()
    {
        foreach (GameObject trash in allTrash)
        {
            if (trash != null)
            {
                Destroy(trash);
            }
        }

        allTrash.Clear();
        trashCount = 0;

        Debug.Log("Reset : toutes les poubelles supprimées");
    }
}