﻿namespace EF_DotNetFramework.Models
{
    class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
