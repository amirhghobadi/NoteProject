using System;
using System.ComponentModel.DataAnnotations;

namespace NoteProject.Models
{

    public class Note
    {


        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا عنوان را وارد کنید")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "لطفا متن یادداشت را وارد کنید")]
        public required string Content { get; set; }



        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; } = DateTime.Now;





    }


}