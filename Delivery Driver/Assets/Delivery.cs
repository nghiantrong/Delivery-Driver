using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
     bool hasPackage;
     [SerializeField] float delay = 0.5f;
     [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
     [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
     SpriteRenderer spriteRenderer;

     private void Start() {
      spriteRenderer = GetComponent<SpriteRenderer>();
     }

   private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision is happening");
   }

   private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage) {
          Debug.Log("Package picked up");
          hasPackage = true;
          spriteRenderer.color = hasPackageColor;
          Destroy(other.gameObject, delay);

        } else if (other.tag == "Customer" && hasPackage == true) {
          Debug.Log("Delivered package");
          hasPackage = false;
          spriteRenderer.color = noPackageColor;
        }
   }
}
