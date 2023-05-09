using DefaultNamespace.UI;
using Tanx.Timeline;
using UDT.Core;

namespace DefaultNamespace
{
    public class TanxRuntime : Runtime<TanxRuntime>
    {
        //Global Systems
        void Start()
        {
            Director.StartSystem();
        }
        
        public class Credits : State<TanxRuntime>
        {
            public override void Enter()
            {
                CreditsSystem.StartSystem();
                CreditsSystem.OnCreditsEnd.AddMethod(OnCreditsEnd);
            }

            public override void Exit()
            {
                CreditsSystem.StopSystem();
            }
            
            public void OnCreditsEnd()
            {
                SetState("MainMenu");
            }
        }
        
        public class MainMenu : State<TanxRuntime>
        {
            
        }
        
        public class Settings : State<TanxRuntime>
        {
            
        }
        
        public class Shop : State<TanxRuntime>
        {
            
        }
        
        public class Game : State<TanxRuntime>
        {
            
        }
    }
}