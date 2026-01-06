using UnityEngine;
using System.Collections.Generic; // Needed for Lists

public class BodyPartRevealer : MonoBehaviour
{
    // This allows you to group data in the Inspector
    [System.Serializable]
    public class PartToReveal
    {
        public string name;             // Just for your own labels (e.g. "Skull")
        public Renderer renderer;       // The mesh (Body, Skull, etc)
        public int materialIndex;       // The slot number (0, 3, etc)
        [HideInInspector] public Material originalMaterial; // Secret storage
    }

    [Header("Global Settings")]
    public Material xRayMaterial;

    [Header("Parts List")]
    // This creates a list you can expand in the Inspector with the "+" button
    public List<PartToReveal> bodyParts;

    void Start()
    {
        // Loop through every part in your list and save its original skin
        foreach (PartToReveal part in bodyParts)
        {
            if (part.renderer != null && part.renderer.materials.Length > part.materialIndex)
            {
                part.originalMaterial = part.renderer.materials[part.materialIndex];
            }
        }
    }

    public void ShowInternal()
    {
        Debug.Log("HOVER DETECTED on: " + gameObject.name);
        foreach (PartToReveal part in bodyParts)
        {
            if (part.renderer != null)
            {
                Material[] mats = part.renderer.materials;
                if (mats.Length > part.materialIndex)
                {
                    mats[part.materialIndex] = xRayMaterial;
                    part.renderer.materials = mats;
                }
            }
        }
    }

    public void HideInternal()
    {
        foreach (PartToReveal part in bodyParts)
        {
            if (part.renderer != null)
            {
                Material[] mats = part.renderer.materials;
                if (mats.Length > part.materialIndex)
                {
                    mats[part.materialIndex] = part.originalMaterial;
                    part.renderer.materials = mats;
                }
            }
        }
    }
}