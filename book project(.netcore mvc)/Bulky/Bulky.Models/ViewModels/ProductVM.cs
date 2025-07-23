using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace Bulky_Models.ViewModels
{
    public class ProductVM
    {
        // view models are models that are specifically designed with view 
        // also called as strongly typed views - means there is a model that is specific for a view 
        // instead of using viewbag or viewdata we are using view model
        // view model is a class that contains the data that we want to pass to the view
        //here we tightly bind ur view to the object that u want 
        public Product Product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> categorylist { get; set; }
    }
}
