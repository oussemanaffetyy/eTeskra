﻿using eTeskra.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTeskra.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
		[Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Logo is Required !!")]
        public string Logo { get; set; }
		[Display(Name = "Name")]
        [Required(ErrorMessage = "Name is Required !!")]
        public string Name { get; set; }
		[Display(Name = "Description")]
        [Required(ErrorMessage = "Description is Required !!")]
        public string Description { get; set; }

        //Relationship
        public List<Movie>? Movies { get; set; }
    }
}
