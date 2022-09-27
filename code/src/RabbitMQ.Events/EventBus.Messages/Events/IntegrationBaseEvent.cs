namespace EventBus.Messages.Events
{
    public class IntegrationBaseEvent
    {
        public Guid id { get; set; }
        public DateTime created { get; set; }

        public IntegrationBaseEvent()
        {
            id = Guid.NewGuid();    
            created = DateTime.Now;
        }
    }
}
