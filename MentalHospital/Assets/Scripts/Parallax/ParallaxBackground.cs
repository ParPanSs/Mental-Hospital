using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class ParallaxBackground : MonoBehaviour
{
   public ParallaxCamera parallaxCamera;
   private List<ParallaxLayer> _parallaxLayers = new List<ParallaxLayer>();

   private void Start()
   {
      if (parallaxCamera == null)
         parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();
      if (parallaxCamera != null)
         parallaxCamera.onCameraTranslate += Move;
      SetLayers();
   }

   void SetLayers()
   {
      _parallaxLayers.Clear();
      for (int i = 0; i < transform.childCount; i++)
      {
         ParallaxLayer layer = transform.GetChild(i).GetComponent<ParallaxLayer>();

         if (layer != null)
         {
            layer.name = "Layer-" + 1;
            _parallaxLayers.Add(layer);
         }
      }
   }

   void Move(float delta)
   {
      foreach (ParallaxLayer layer in _parallaxLayers)
      {
         layer.Move(delta);
      }
   }
}
