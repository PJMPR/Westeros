using System;

namespace Westeros.Diet.Data
{

    public class Diary
    {
        public int Id { get; }
        public Entry Entry { get; }

        public Diary(int id, Entry entry)
        {
            Id = id;
            Entry = entry;


        }
    }
}
