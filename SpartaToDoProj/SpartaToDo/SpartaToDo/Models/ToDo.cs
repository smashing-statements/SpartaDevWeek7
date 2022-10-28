using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SpartaToDo.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        //below uses the ! dammit operator
        //when it generates a DB it will have 
        //a constraint saying not null
        //it's a null forgiving operator 
        //it does nothing to the code
        //but it communicates to the IDE
        //that this will not be null when 
        //we use it

        //Required means that it
        //cannot be null
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name = "Complete?")]
        public bool Complete { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime Date { get; init; } = DateTime.Now;


    }
}
