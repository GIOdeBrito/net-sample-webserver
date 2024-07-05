namespace UserView.Models
{
    public class UserViewModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private int _age;
        public int Age
        {
            get => _age;
            set => _age = value;
        }
        
        public UserViewModel (string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}