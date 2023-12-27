using eTeskra.Data.Base;
using eTeskra.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTeskra.Models
{
    public class NewMovieVM 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required !!")]
		[Display(Name = "Movie Name")]
		public string ?Name { get; set; }

		[Required(ErrorMessage = "Description is Required !!")]
		[Display(Name = "Movie Description")]
		public string ?Description { get; set; }

		[Required(ErrorMessage = "Price is Required !!")]
		[Display(Name = "Movie Price")]
		public double Price { get; set; }

		[Required(ErrorMessage = "Movie Poster URL is Required !!")]
		[Display(Name = "Movie Poster URL")]
		public string ?ImageUrl { get; set; }

		[Required(ErrorMessage = "Start Date is Required !!")]
		[Display(Name = "Movie start date")]
		public DateTime StartDate { get; set; }

		[Required(ErrorMessage = "End Date is Required !!")]
		[Display(Name = "Movie end date")]
		public DateTime EndDate { get; set; }

		[Required(ErrorMessage = "Movie Category is Required !!")]
		[Display(Name = "Select a Category")]
		public MovieCategory MovieCategory { get; set; }

		//Relationship
		[Required(ErrorMessage = "Movie Actor(s) is Required !!")]
		[Display(Name = "Select a Actor(s)")]
		public List<int>? ActorIds { get; set; }

		[Required(ErrorMessage = "Movie Cinema is Required !!")]
		[Display(Name = "Select a Cinema")]
		public int CinemaId { get; set; }

		[Required(ErrorMessage = "Movie Producer is Required !!")]
		[Display(Name = "Select a Producer")]
		public int ProducerId { get; set; }
      
    }
}
