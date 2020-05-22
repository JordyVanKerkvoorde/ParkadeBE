using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingAppAPI.DTO;
using ParkingAppAPI.Models;

namespace ParkingAppAPI.Controllers {
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private ISuggestionRepository _suggestions;

        public SuggestionController(ISuggestionRepository suggestions) {
            _suggestions = suggestions;
        }


        // GET: api/Suggestions/1
        /// <summary>
        /// Returns all the suggestions in the database
        /// </summary>
        /// <returns>Suggestion</returns>
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
            Console.WriteLine("post method called");
            Console.WriteLine(suggestion.ToString());
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