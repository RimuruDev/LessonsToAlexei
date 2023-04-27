public sealed class ProjectLoopPattern
{
    private bool canQuitApplication = false;

    public void Update(Action logicForLoop)
    {
        while (!canQuitApplication)
            logicForLoop?.Invoke(); // ?. - The Null Save Invoke
    }

    public void QuitApplication() => 
        canQuitApplication = true;
}
