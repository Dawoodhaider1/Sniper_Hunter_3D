using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTextureSwapper : MonoBehaviour
{
    public Material[] materials;  // An array of materials to swap between
    private Renderer Renderer;    // Reference to the renderer component of the game object

    private int currentIndex; // Index of the current material in the array

    void Start()
    {
        // Get the renderer component of the game object
        Renderer = GetComponent<Renderer>();
        currentIndex = GameManager.Instance.Gun_Number;

        // Set the initial material
        if (materials.Length > 0)
        {
            Renderer.material = materials[currentIndex];
        }
    }


}
