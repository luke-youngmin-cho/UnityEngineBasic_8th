using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : SingletonBase<PauseController>
{
    public enum State
    {
        None,
        Playing,
        Paused
    }
    public State state;

    private List<IPausable> _pausables = new List<IPausable>();

    public void Register(IPausable pausable)
    {
        _pausables.Add(pausable);
        pausable.Pause(state == State.Paused);
    }

    protected override void Init()
    {
        base.Init();
        InputManager.instance.global.AddKeyDownAction(KeyCode.BackQuote, () =>
        {
            state = state == State.Paused ? State.Playing : State.Paused;
            InputManager.instance.enabledCurrent = state == State.Paused ? false : true;
            Time.timeScale = state == State.Paused ? 0.0f : 1.0f;
            foreach (var pausable in _pausables)
            {
                pausable.Pause(state == State.Paused);
            }
        });
    }
}
