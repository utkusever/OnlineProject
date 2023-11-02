using _Game.Scripts.Base.UserInterface;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace _Game.Scripts.UserInterface.Canvases
{
    public class InGameUI : AbstractBaseCanvas
    {
        [SerializeField] private TMP_Text healthPotionCountText;
        [SerializeField] private TMP_Text homingRocketCountText;
        [SerializeField] private TMP_Text damageBoosterCountText;
        [SerializeField] private Image bulletImage;

        // [SerializeField] private TMP_Text distanceText;

        // public OnUIButtonClickEvent Pause;

        // public void SetDistanceText(string distance) => distanceText.text = distance;
        public override void OnStart()
        {
            Debug.Log("InGameUI Enabled");
        }

        public override void OnQuit()
        {
            Debug.Log("InGameUI Disabled");
        }

        // public void OnPauseClick()
        // {
        //     Pause.Invoke();
        // }
        public void UpdateInventoryUI(ItemType itemToAdd, int value)
        {
            switch (itemToAdd)
            {
                case ItemType.HealthPotion:
                    healthPotionCountText.text = value.ToString();
                    break;
                case ItemType.DamageBooster:
                    damageBoosterCountText.text = value.ToString();
                    break;
                case ItemType.HomingRocket:
                    homingRocketCountText.text = value.ToString();
                    break;
            }

        }
        public void BulletOverlayFill(float duration)
        {
            bulletImage.fillAmount = 0;
            bulletImage.DOFillAmount(1, duration);

        }
    }
}
