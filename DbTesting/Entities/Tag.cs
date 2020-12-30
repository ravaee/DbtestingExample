using System;
using System.Collections.Generic;
using System.Text;

namespace DbTesting.Entities
{
    public class Tag
    {
        private readonly int _id;

        public Tag()
        {

        }

        private Tag(int id, string label)
        {
            _id = id;
            Label = label;
        }

        public Tag(string label) => Label = label;

        public string Label { get; }

        public int Count { get; set; }
    }
}
