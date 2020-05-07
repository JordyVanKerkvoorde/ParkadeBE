using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingAppAPI.DTO;
using ParkingAppAPI.Models;

namespace ParkingAppAPI.Controllers {
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private ISuggestionRepository _suggestions;

        public SuggestionController(ISuggestionRepository suggestions) {
            _suggestions = suggestions;
        }

        [HttpGet]
        public IEnumerable<Suggestion> GetSuggestions() {
            return _suggestions.GetSuggestions();
        }

        // GET: api/Suggestions/1
        /// <summary>
        /// Get the suggestion with the given ID
        /// </summary>
        /// <param name="id">the id of the suggestion</param>
        /// <returns>Suggestion</returns>
        [HttpGet("{id}")]
        public ActionResult<Suggestion> GetSuggestion(int id) {
            return _suggestions.GetSuggestion(id);
        }

        // POST: api/Suggestions
        /// <summary>
        /// Adds a suggestion created by the user to the database
        /// </summary>
        /// <param name="suggestion">the suggestion</param>
        [HttpPost]
        public ActionResult<Suggestion> PostSuggestion(SuggestionDTO suggestion) {
            Suggestion suggestionToCreate = new Suggestion() {
                Name = suggestion.Name,
                Longtitude = suggestion.Longtitude,
                Latitude = suggestion.Latitude,
                Description = suggestion.Description
            };
            _suggestions.Add(suggestionToCreate);
            _suggestions.SaveChanges();

            return CreatedAtAction(nameof(GetSuggestion), new { id = suggestionToCreate.Id}, suggestionToCreate);
        }
    }

    
}