namespace BasicAPI
{
    public class DataContext:IDataContext
    {
        public int count=0;
       public List<Event> Events { get; set; }  
     public DataContext()
        {
            Events = new List<Event>(); 
            Events.Add(new Event { Id=count++,start=DateTime.Now,end=DateTime.Now});    
        }
    }
}
