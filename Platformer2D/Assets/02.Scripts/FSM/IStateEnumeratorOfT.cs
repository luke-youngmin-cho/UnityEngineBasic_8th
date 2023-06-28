public interface IStateEnumerator<T>
    where T : System.Enum
{
    public enum Step
    {
        None,
        Start,
        Casting,
        DoAction,
        WaitUntilActionFinished,
        Finish
    }

    Step current { get; }
    bool canExecute { get; }
    T MoveNext();
    void Reset();
}
