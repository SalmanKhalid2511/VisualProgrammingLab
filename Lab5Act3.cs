using System;
public class WorkItem
{
    private static int currentID;
    protected int ID { get; set; }
    protected string Title { get; set; }
    protected string Description { get; set; }
    protected TimeSpan joblength {  get; set; }

    public WorkItem()
    {
        ID = 0;
        Title = "Default title ";
        Description = "Default description. "; joblength = new TimeSpan();
    }                                        
    public WorkItem(string title ,string desc , TimeSpan joblen)
    {
        this.ID = GetNextID(); this.Title = title; this.Description = desc; this.joblength = joblen;

    }
    static WorkItem()
    {
        currentID = 0;
    }
    protected int GetNextID()
    {
        return ++currentID;
    }
    public void Update(string title , TimeSpan joblen)
    {
        this.Title = title;
        this.joblength = joblen;
    }
    public override string ToString()
    {
        return String.Format("{0} - {1} ", this.ID , this.Title );
    }


}
namespace std
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkItem workItem = new WorkItem();
        }
    }
}
