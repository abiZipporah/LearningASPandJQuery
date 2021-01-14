using System;
using System.Collections.Generic;

namespace LearningStuff.Models
{
    public class btCategories
    {
        public List<Bookingtype> bookingTypes { get; set; }
    }
   public class Bookingtype
    {
        public string name { get; set; }
    }
    public class bTypes
    {
        public List<bookingTypes> bookingTypes { get; set; }
    }
    public class bookingTypes
    {
        public int id { get; set; }
        public string name { get; set; }
        public string bookingTypeCategory { get; set; }
    }
    public class Resources
    {
        public List<resources> resources { get; set; }
    }
    public class resources
    {
        public int id { get; set; }
        public string name { get; set; }
        public int resourceCategoryId { get; set; }
        public string resourceCategoryName { get; set; }
    }
}
