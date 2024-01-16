public interface IObserver
{
    void Update();
}

public class Observer : IObserver
{
    private readonly Action updateAction;

    public Observer(Action updateAction)
    {
        this.updateAction = updateAction;
    }

    public void Update()
    {
        updateAction?.Invoke();
    }
}
