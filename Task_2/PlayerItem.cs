namespace Task_2
{
    public class PlayerItem
    {
        private readonly string _path;
        public readonly string Name;

        public PlayerItem(string path, string name)
        {
            _path = path;
            Name = name;
        }

        public string Extension => Name.Substring(Name.LastIndexOf('.') + 1);
    }
}