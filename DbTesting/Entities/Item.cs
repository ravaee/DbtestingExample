using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DbTesting.Entities
{
    public class Item
    {
        [Key]
        public int _id { get; set; }
        private readonly List<Tag> _tags = new List<Tag>();

        public Item()
        {

        }

        public Item(int id, string name)
        {
            _id = id;
            Name = name;
        }

        public Item(string name)
        {
            Name = name;
        }

        public Tag AddTag(string label)
        {
            var tag = _tags.FirstOrDefault(t => t.Label == label);

            if (tag == null)
            {
                tag = new Tag(label);
                _tags.Add(tag);
            }

            tag.Count++;

            return tag;
        }

        public string Name { get; set; }

        public IReadOnlyList<Tag> Tags => _tags;
    }
}
