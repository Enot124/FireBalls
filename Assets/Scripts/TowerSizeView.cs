using TMPro;
using UnityEngine;

public class TowerSizeView : MonoBehaviour
{
   [SerializeField] private TMP_Text _sizeView;
   [SerializeField] private Tower _tower;

   private void OnEnable()
   {
      _tower.SizeUpdated += onSizeUpdated;
   }

   private void OnDisable()
   {
      _tower.SizeUpdated -= onSizeUpdated;
   }

   private void onSizeUpdated(int size)
   {
      _sizeView.text = size.ToString();
   }
}
