using System.Collections.Generic;

namespace geektrust.Model
{
    public class InputRequest
    {
        public IReadOnlyCollection<Request> Requests { get; } 

        public InputRequest(IReadOnlyCollection<Request> requests)
        {
            Requests = requests;
        }
    }
}
