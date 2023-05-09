using UDT.Core;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Tanx.Timeline
{
    public class Director : System<Director>
    {
        public PlayableDirector playableDirector;
        
        /// <summary>
        /// Declared when the director is played
        /// </summary>
        public static StandardEvent<PlayableDirector> OnDirectorPlay;
        /// <summary>
        /// Declared when the director is paused
        /// </summary>
        public static StandardEvent<PlayableDirector> OnDirectorPause;
        /// <summary>
        /// Declared when the director is stopped
        /// </summary>
        public static StandardEvent<PlayableDirector> OnDirectorStop;

        void Start()
        {
            playableDirector = gameObject.AddComponent<PlayableDirector>();
            
            // Register events
            playableDirector.stopped += OnDirectorStop.Invoke;
            playableDirector.played += OnDirectorPlay.Invoke;
            playableDirector.paused += OnDirectorPause.Invoke;
            
            // Register states
            OnDirectorPlay.Action += Play;
            OnDirectorPause.Action += Pause;
            OnDirectorStop.Action += Stop;
        }
        
        public static void PlayTimeline(TimelineAsset timeline)
        {
            Instance.playableDirector.playableAsset = timeline;
            SetState("Playing");
        }
        
        
        public void Play(PlayableDirector director)
        {
            SetState("Playing");
        }
        
        public void Pause(PlayableDirector director)
        {
            SetState("Paused");
        }
        
        public void Stop(PlayableDirector director)
        {
            SetState("Stopped");
        }
        
        public class Playing : State<Director>
        {
            public override void Enter()
            {
                Director.OnDirectorPlay?.Invoke(root.playableDirector);
            }
        }
        
        public class Paused : State<Director>
        {
            public override void Enter()
            {
                root.playableDirector.Pause();
                Director.OnDirectorPause?.Invoke(root.playableDirector);
            }
        }
        
        public class Stopped : State<Director>
        {
            public override void Enter()
            {
                Director.OnDirectorStop?.Invoke(root.playableDirector);
            }
        }
    }
}