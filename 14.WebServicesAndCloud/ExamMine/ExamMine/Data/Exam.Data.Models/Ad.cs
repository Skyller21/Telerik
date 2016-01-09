//namespace Exam.Data.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;

//    public class Ad
//    {
//        private ICollection<Comment> comments;

//        public Ad()
//        {
//            this.comments = new HashSet<Comment>();
//        }

//        public int RealEstateId { get; set; }

//        public virtual RealEstate RealEstate { get; set; }

//        public int Id { get; set; }

//        public int Views { get; set; }

//        public DateTime CreationDate { get; set; }

//        [Required]
//        public PublishType PublishType { get; set; }

//        public virtual ICollection<Comment> Comments
//        {
//            get { return this.comments; }
//            set { this.comments = value; }
//        }
//    }
//}