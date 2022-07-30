using UnityEngine;

public class Gun : MonoBehaviour
{
   [SerializeField] private Transform shootPoint;
   [SerializeField] private Bullet bulletTemplate;
   [SerializeField] private float delayBetweenShoots;
   private float timeAfterShoot;

   private void Update()
   {
      timeAfterShoot += Time.deltaTime;

      if (Input.GetMouseButtonDown(0))
      {
         if (timeAfterShoot > delayBetweenShoots)
         {
            Shoot();
            timeAfterShoot = 0;
         }
      }
   }

   private void Shoot()
   {
      Instantiate(bulletTemplate, shootPoint.position, Quaternion.identity);
   }
}
