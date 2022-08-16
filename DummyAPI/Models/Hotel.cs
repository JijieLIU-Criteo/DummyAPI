using System;

namespace DummyAPI.Models
{
    public class Hotel : Resource
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Eamil { get; set; }
        public string Website { get; set; }
        public Address address { get; set; }
    }
}

