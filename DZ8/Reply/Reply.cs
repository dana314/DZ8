public class Reply
{
    public string Text { get; set; } 
    public DateTime Date { get; set; }  
    public Person Employee { get; set; }

    public Reply(string text, DateTime date, Person employee)
    {
        Text = text;  
        Date = date;  
        Employee = employee;  
    }
}
