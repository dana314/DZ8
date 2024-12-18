using System;
public class Song
{
    private string name; 
    private string author; 
    private Song previous;
    public Song(string name, string author)
    {
        this.name = name;
        this.author = author;
        this.previous = null;
    }
    public Song(string name, string author, Song previous)
    {
        this.name = name;
        this.author = author;
        this.previous = previous;
    }

    public void Name(string name)
    {
        this.name = name;
    }
    public void Author(string author)
    {
        this.author = author;
    }
    public void Previous(Song prev)
    {
        this.previous = prev;
    }
    public string View()
    {
        return $"{author}: {name}";
    }
    public override bool Equals(object obj)
    {
        if (obj is Song otherSong)
        {
            return this.name == otherSong.name && this.author == otherSong.author;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, author);
    }
}
