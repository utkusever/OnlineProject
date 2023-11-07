using _Game.Scripts.Base.UserInterface;
using TMPro;
using UnityEngine;

namespace _Game.Scripts.UserInterface.Canvases
{
    public class CounterUI : AbstractBaseCanvas
    {
        [SerializeField] private TMP_Text counterText;

        public override void OnStart()
        {
            Debug.Log("Enabled CounterUI");
        }

        public void SetCounterText(string counter) => counterText.text = counter;
    }
}