using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Models {
    public interface ISuggestionRepository{
        Suggestion GetSuggestion(int id);
        IEnumerable<Suggestion> GetSuggestions();
        void Add(Suggestion suggestion);
        void SaveChanges();
    }
}
