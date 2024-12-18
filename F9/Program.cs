// 1F
using System;
public class Program
{
    static void Main(string[] args)
    {
        Task1f();
    }
    static void Task1f()
    {
        List<Song> songs = new List<Song>
        {
            new Song("Song a", "Author 1"),
            new Song("Song b", "Author 2"),
            new Song("Song c", "Author 3"),
            new Song("Song d", "Author 4")
        };
        foreach (var song in songs)
        {
            Console.WriteLine(song.View());
        }
        if (songs[0].Equals(songs[1]))
        {
            Console.WriteLine("первая и вторая песни одинаковыe");
        }
        else
        {
            Console.WriteLine("первая и вторая песни разные");
        }
        Song mySong = new Song("my song", "my author");
    }
}
public class Project
{
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public Person Initiator { get; set; }
    public Person TeamLead { get; set; }
    public List<Task> Tasks { get; set; }
    public ProjectStatus Status { get; set; }

    public Project(string description, DateTime deadline, Person initiator, Person teamLead)
    {
        Description = description;
        Deadline = deadline;
        Initiator = initiator;
        TeamLead = teamLead;
        Tasks = new List<Task>();
        Status = ProjectStatus.Project;
    }

    public void AddTask(Task task)
    {
        if (Status == ProjectStatus.Project)
        {
            Tasks.Add(task);
        }
        else
        {
            throw new InvalidOperationException("нельзя добавить задачу");
        }
    }

    public void StartProject()
    {
        if (Status == ProjectStatus.Project)
        {
            Status = ProjectStatus.InProgress;
        }
    }

    public bool IsCompleted()
    {
        foreach (var task in Tasks)
        {
            if (task.Status != TaskStatus.Completed)
            {
                return false;
            }
        }
        return true;
    }

    public void CloseProject()
    {
        if (IsCompleted())
        {
            Status = ProjectStatus.Closed;
        }
        else
        {
            throw new InvalidOperationException("нельзя закрыть прокт");
        }
    }
}