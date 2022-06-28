public class Student
{
    public string Name { get; set; }
    
    public int Grade { get; set; }

    private int _age;
    public int Age 
    { 
        get => _age;
        set
        {
            if(value < 0)
                _age = 0;
            else
                _age = value;
        }
    }
}
