using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Logic
{
    [Table("Todos")]
    public partial class ToDo : ITodo
    {
        private bool _is_finished;

        public int id { get; set; }
        public DateTime date_added { get; set; }
        public DateTime? date_finished { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("is_finished")]
        public bool IsFinished
        {
            get { return _is_finished; }
            set
            {
                if (value == true)
                    date_finished = DateTime.Now;
                else
                    date_finished = null;
                _is_finished = value;
            }
        }

        public ToDo(string title, string content)
        {
            Title = title;
            Content = content;
            date_added = DateTime.Now;
            IsFinished = false;
        }

        public ToDo(){ }
    }
}
