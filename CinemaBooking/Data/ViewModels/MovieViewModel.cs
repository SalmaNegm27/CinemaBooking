﻿using CinemaBooking.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaBooking.Data.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name of the Movie is Required")]
        public string Name { get; set; }
        public string? ImagePath { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        [StringLength(100, MinimumLength = 10)]
        public string Description { get; set; }

        [Required(ErrorMessage = "StartDate is Required")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is Required")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yy}", ApplyFormatInEditMode = true)]

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Price is Required")]

        public decimal Price { get; set; }

        [Required]
        public MovieCategory MovieCategory { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "Choose Cinema")]
        public int SelectedCinemaId { get; set; }
        public List<CinemaViewModel> Cinemas { get; set; } = new List<CinemaViewModel>();
        [Required(ErrorMessage = "Choose Producer")]

        public int SelectedProducerId { get; set; }
        public List<ProducerViewModel> Producers { get; set; } = new List<ProducerViewModel>();
    }
}



