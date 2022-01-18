using ViewsApp.Components;

namespace ViewsApp.Models
{
    [ViewComponent]
    public class Timer
    {
        public string Invoke()
        {
            return $"Текущее время: {System.DateTime.Now.ToString("hh:mm:ss")}";
        }
    }
}
