using System;
using _Game.Scripts.Base.UserInterface;
using TMPro;
using UnityEngine;
using DG.Tweening;
using Unity.Netcode;
using UnityEngine.UI;

namespace _Game.Scripts.UserInterface.Canvases
{
    public class InGameUI : AbstractBaseCanvas
    {
        [SerializeField] private TMP_Text healthPotionCountText;
        [SerializeField] private TMP_Text homingRocketCountText;
        [SerializeField] private TMP_Text damageBoosterCountText;
        [SerializeField] private TMP_Text kamikazeCountText;

        [SerializeField] private Image bulletImage;
        [SerializeField] private Button minesGenerateButton;
        [SerializeField] private TMP_InputField countText;


        // [SerializeField] private TMP_Text distanceText;

        // public OnUIButtonClickEvent Pause;

        // public void SetDistanceText(string distance) => distanceText.text = distance;
        public override void OnStart()
        {
            Debug.Log("InGameUI Enabled");
            minesGenerateButton.onClick.AddListener(GenerateMines);
        }

        public override void OnQuit()
        {
            Debug.Log("InGameUI Disabled");
            minesGenerateButton.onClick.RemoveListener(GenerateMines);
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
                case ItemType.Kamikaze:
                    kamikazeCountText.text = value.ToString();
                    break;
            }
        }

        public void BulletOverlayFill(float duration)
        {
            bulletImage.fillAmount = 0;
            bulletImage.DOFillAmount(1, duration);
        }

        private void GenerateMines()
        {
            GameManager.Instance.GetGenerator().GenerateItem(ItemType.Mine, int.Parse(countText.text));
        }
    }
}