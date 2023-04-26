public sealed class ProjectLoopPattern
{
    private bool canQuitApplication = false;

    public void Update(Action logicForLoop)
    {
        while (!canQuitApplication)
            logicForLoop?.Invoke(); // ?. Null Save Invoke - Проверка события на null на подпискиков, или хранится ли в нем что то
    }

    public void QuitApplication() => 
        canQuitApplication = true;
}