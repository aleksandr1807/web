using System;
using System.Collections.Generic;
using System.Text;

namespace WebLabs.DAL.Entities
{
   public class Tehnika
    {
        public int TehnikaId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int ArendaDays { get; set; }
        public string Images { get; set; }
        // Навигационные свойства
        /// <summary>
        /// группа блюд (например, супы, напитки и т.д.)
        /// </summary>
        public int TehnikaGroupId { get; set; }
        public TehnikaGroup Group { get; set; }
    }
}
