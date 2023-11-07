using System;
using _Game.Scripts.Base.UserInterface;

namespace _Game.Scripts.UserInterface.Canvases
{
    public class PauseUI : AbstractBaseCanvas
    {
        public OnUIButtonClickEvent Resume;
        public OnUIButtonClickEvent Reset;

        public void ResumeGame()
        {
            Resume.Invoke();
        }

        public void ResetGame()
        {
            Reset.Invoke();
        }
    }
}
