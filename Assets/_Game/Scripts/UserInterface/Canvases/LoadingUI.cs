using System.Collections;
using _Game.Scripts.Base.UserInterface;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.UserInterface.Canvases
{
    public class LoadingUI : AbstractBaseCanvas
    {
        [SerializeField] private Image loadingFill;

        public float LoadingTime { get; set; }

        public override void OnStart()
        {
            Debug.Log("LoadingUI Enabled");
            StartCoroutine(FillBar());
        }

        public override void OnQuit()
        {
            Debug.Log("LoadingUI Disabled");
            StopAllCoroutines();
        }

        private IEnumerator FillBar()
        {
            float elapsedTime = 0;
            while (elapsedTime <= LoadingTime)
            {
                loadingFill.fillAmount = elapsedTime / LoadingTime;
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
