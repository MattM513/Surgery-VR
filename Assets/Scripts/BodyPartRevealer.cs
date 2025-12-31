using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BodyPartRevealer : MonoBehaviour
{
    [Header("Settings")]
    public SkinnedMeshRenderer targetMesh;  // Drag the CC_Base_Body here
    public int materialIndexToSwap;         // The index number (e.g., 3 for Body, 5 for Head)
    public Material xRayMaterial;           // Drag your Mat_Surgery_Glass here

    private Material originalMaterial;

    void Start()
    {
        // 1. Remember what the skin looked like originally
        originalMaterial = targetMesh.materials[materialIndexToSwap];
    }

    public void ShowInternal()
    {
        Debug.Log("HOVER DETECTED on: " + gameObject.name);
        // 2. Create a copy of the current material list
        Material[] currentMats = targetMesh.materials;

        // 3. Swap only the specific slot to Glass
        currentMats[materialIndexToSwap] = xRayMaterial;

        // 4. Apply the list back to the renderer
        targetMesh.materials = currentMats;
    }

    public void HideInternal()
    {
        // Revert back to original skin
        Material[] currentMats = targetMesh.materials;
        currentMats[materialIndexToSwap] = originalMaterial;
        targetMesh.materials = currentMats;
    }
}