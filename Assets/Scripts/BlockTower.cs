using UnityEngine;
using UnityEngine.Events;

public class BlockTower : MonoBehaviour
{
   public event UnityAction<BlockTower> BulletHit;
   public void Break()
   {
      BulletHit?.Invoke(this);
      Destroy(gameObject);
   }
}
