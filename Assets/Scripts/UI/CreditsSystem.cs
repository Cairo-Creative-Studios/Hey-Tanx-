using UDT.Core;
using UnityEngine.Timeline;

namespace DefaultNamespace.UI
{
    public class CreditsSystem : System<CreditsSystem>
    {
        public static StandardEvent OnCreditsEnd;
        
        /// <summary>
        /// The timeline clip that contains the credits
        /// </summary>
        private TimelineClip creditsClip;
        
        public class Credits : State<CreditsSystem>
        {
            public override void Enter()
            {
                
            }

            public override void Update()
            {
                OnCreditsEnd?.Invoke();
            }
        }
    }
}