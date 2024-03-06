
public class Filter
{
    //more exact setter needed
    public string type {get; set;}
    public int difficulty {get; set;}

    Filter(string type, int difficulty)
    {
        this.type = type; 
        this.difficulty = difficulty;
    }
}