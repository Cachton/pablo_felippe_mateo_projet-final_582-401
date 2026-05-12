using System.Collections.Generic;
using UnityEngine;

public class TrashZone : MonoBehaviour
{
    public int trashCount = 0;
    public int limit = 5;

    // Liste de tous les sacs actifs
    public static List<GameObject> allTrash = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            // Ajouter si pas déjà listé
            if (!allTrash.Contains(other.gameObject))
            {
                allTrash.Add(other.gameObject);
            }

            trashCount++;

            Destroy(other.gameObject);

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