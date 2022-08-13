using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField] private float _speed;
   [SerializeField] private float _bounseForce;
   [SerializeField] private float _bounseDistance;
   private Vector3 _moveDirection;

   void Start()
   {
      _moveDirection = Vector3.left;
   }

   void Update()
   {
      transform.Translate(_moveDirection * _speed * Time.deltaTime);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out BlockTower block))
      {
         block.Break();
         Destroy(gameObject);
      }

      if (other.TryGetComponent(out ObstacleChapter obstacleChapter))
      {
         _moveDirection = Vector3.right + Vector3.up;
         Rigidbody rigidbody = GetComponent<Rigidbody>();
         rigidbody.isKinematic = false;
         rigidbody.AddExplosionForce(_bounseForce, transform.position + new Vector3(0, -1, 1), _bounseDistance);
      }
   }

}
