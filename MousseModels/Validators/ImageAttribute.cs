using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;

namespace MousseModels.Validators
{
    class ImageAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            byte[] file = value as byte[];
            if (file == null)
            {
                return new ValidationResult("Aucun fichier n'est upload");
            }
            MemoryStream ms = new MemoryStream(file);
            Image image = Image.FromStream(ms);
            if(Equals(ImageFormat.Jpeg,image)|| Equals(ImageFormat.Gif, image)|| Equals(ImageFormat.Png, image))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Le fichier n'est pas au format png, jpg, jpeg ou gif");
        }
    }
}
