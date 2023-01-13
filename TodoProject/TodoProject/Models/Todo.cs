using System;
using SQLite;
namespace TodoProject.Models
{
    public class Todo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public String state { get; set; }
    }
}