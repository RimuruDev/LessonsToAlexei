public sealed class DataBase // Model
{
    // Одновременно поле, метод Get, метод Set. Или опционально настраиваемо по отдельности или то или другое.
    public List<Item> Items { get; private set; } = new();
    public List<Putan> Putans { get; private set; } = new();

    // Old Property version.
    private List<Item> _Items;
    public List<Item> GetItems() => Items;
    public void SetItems(Item item) => Items.Add(item);

    // Old Property version.
    private List<Putan> _Putans;
    public List<Putan> GetPutans() => Putans;
    public void SetPutan(Putan person) => Putans.Add(person);
}