namespace MyFirstMvcApp.Services
{
    public class TimeService: ITimeService
    {
        private readonly DateTime _createdTime;
        public TimeService()
        {
            _createdTime = DateTime.Now;
        }
        public DateTime GetCurrentTime()
        {
            return _createdTime;
        }
    }
   
    public interface ITimeService
    {
        DateTime GetCurrentTime();
    }
}
