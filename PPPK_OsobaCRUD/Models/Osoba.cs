using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPPK_OsobaCRUD.Models
{
    public class Osoba
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "First name can not be longer than 30 characters")]
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Last name can not be longer than 30 characters")]
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }
        [Required]
        [MinLength(11, ErrorMessage = "OIB can not be shorter than 11 characters")]
        [MaxLength(11, ErrorMessage = "OIB can not be longer than 11 characters")]
        [JsonProperty(PropertyName = "oib")]
        public string Oib { get; set; }
        [Required]
        [Range(0, 122, ErrorMessage = "Age can not be less than 0 and more then 122")]
        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }


    }
}