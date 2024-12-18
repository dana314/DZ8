public class Task
{
    public string Description { get; set; } 
    public DateTime Deadline { get; set; }  
    public Person Initiator { get; set; } 
    public Person Employee { get; set; }  
    public TaskStatus Status { get; set; }  
    public Reply TaskReport { get; set; }  

    public Task(string description, DateTime deadline, Person initiator)
    {
        Description = description;  
        Deadline = deadline;  
        Initiator = initiator; 
        Status = TaskStatus.Assigned;  
    }

    
    public void StartTask()
    {
        if (Status == TaskStatus.Assigned)
        {
            Status = TaskStatus.InProgress;  
        }
    }

    public void DelegateTask(Person newEmployee)
    {
        Employee = newEmployee;  
    }

    public void RejectTask()
    {
        Employee = null;  
        Status = TaskStatus.Assigned;  
    }

    
    public void CompleteTask(string reportText, Person employee)
    {
        if (Status == TaskStatus.InProgress)  
        {
            TaskReport = new Reply(reportText, DateTime.Now, employee);  
            Status = TaskStatus.Completed;  
        }
        else
        {
            throw new InvalidOperationException("не может быть завершена, тк находится в разработке");
        }
    }
}
