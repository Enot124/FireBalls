using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
   [SerializeField] private float _towerSize;
   [SerializeField] private Transform _SpawnPoint;
   [SerializeField] private BlockTower _towerBlock;
   [SerializeField] private BlockTower _towerBlock2;
   private List<BlockTower> _towerBlocks;
   private int _blocks = 0;

   public List<BlockTower> Build()
   {
      _towerBlocks = new List<BlockTower>();
      Transform currentPoint = _SpawnPoint;

      for (int i = 0; i < _towerSize; i++)
      {
         BlockTower newBlock = BuildTower(currentPoint);
         _towerBlocks.Add(newBlock);
         currentPoint = newBlock.transform;

      }
      return _towerBlocks;
   }

   private BlockTower BuildTower(Transform CSpawnPoint)
   {
      _blocks++;
      if (_blocks % 2 == 0)
         return Instantiate(_towerBlock, GetSpawnPoint(CSpawnPoint), Quaternion.identity, _SpawnPoint);
      else
         return Instantiate(_towerBlock2, GetSpawnPoint(CSpawnPoint), Quaternion.identity, _SpawnPoint);
   }

   private Vector3 GetSpawnPoint(Transform curBlock)
   {
      return new Vector3(_SpawnPoint.position.x,
                         curBlock.position.y + curBlock.localScale.y * 1.5f + _towerBlock.transform.localScale.y / 2,
                         _SpawnPoint.position.z);
   }
}
