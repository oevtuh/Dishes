(function ($) {
   
    selectDishes();
    
    $(".category-box").change(function () {
      
        selectDishes();
    });

   
    
    var viewModel = new ViewModel();

    ko.applyBindings(viewModel);

    function selectDishes() {
        var ingredients = $.map($('.category-box input:checked'), function(item) {
             return $(item).val();
        });
        
        if (ingredients.length) {
            $.ajax({
                url: 'FindByIngredients',
                type: 'get',
                data: {
                    dishes: ingredients,
                },
                traditional: true,
                dataType: 'json',
                success: function (data) {

                     viewModel.updateDishes(data);
                }
            });
        }
       
    };


 
       $(document).ready(function () {

           $(".plus").show();
           $(".minus").hide();
           $(".ingredient-box").hide();
           $(".category").click(function () {
                
               $(".plus").toggle();
               $(".minus").toggle();
               $(this).siblings(".ingredient-box").fadeToggle();

           });

       });
   





})(jQuery);
