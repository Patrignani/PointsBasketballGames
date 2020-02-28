using Newtonsoft.Json;
using System.Collections.Generic;

namespace PointsBasketballGames.Domain.Core.DTOs.Object
{
    public class ValidateModel
    {
        public ValidateModel(bool success = true)
        {
            Messages = new List<string>();
            Success = success;

        }

        [JsonProperty]
        public bool Success { get; private set; }

        [JsonProperty]
        public List<string> Messages { get; private set; }

        public void SetMessages(IEnumerable<string> messages) => Messages.AddRange(messages);
        public void SetMessages(string message) => Messages.Add(message);
        public void NotValid() => Success = false;
        public void IsValid() => Success = true;
        public void NotValid(string message) {
            Success = false;
            Messages.Add(message);
        }
        public void IsValid(string message) {
            Success = false;
            Messages.Add(message);
        }
    }
}
