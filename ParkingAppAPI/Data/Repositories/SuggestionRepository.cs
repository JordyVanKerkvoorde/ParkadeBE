using Microsoft.EntityFrameworkCore;
using ParkingAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Data.Repositories {
    public class SuggestionRepository : ISuggestionRepository {
        private readonly ParkingContext _context;
        private readonly DbSet<Suggestion> _suggestions;
        public SuggestionRepository(ParkingContext context) {
            _context = context;
            _suggestions = _context.Suggestion;
        }

        public void Add(Suggestion suggestion) {
            _suggestions.Add(suggestion);
        }

        public Suggestion GetSuggestion(int id) {
            return _suggestions.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Suggestion> GetSuggestions() {
            return _suggestions.ToList();
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

    }
}
