(function ($) {
   
    //$(".chzn-select").chosen();
    //$(".chzn-select").change(selectDishes);
  
    var selected = [];
    $(".category-box").change(function () {
      
        selected = [];
        $('.category-box input:checked').each(function () {
            selected.push(+$(this).attr('value'));
        });

        selectDishes();
    });

   
    
    var viewModel = new ViewModel();

    ko.applyBindings(viewModel);

    function selectDishes() {
        //var dishes = [];

        $.ajax({
            url: 'FindByIngredients',
            type: 'get',
            data: {
                //dishes: $(".chzn-select").val(),
                dishes: selected,
            },
            traditional: true,
            dataType: 'json',
            success: function (data) {
                
                //$('.panel-body').empty();
                //$.each(data, function (i) {
                //    $('.panel-body').append('<li><a href="/dishes/' + this.Id + '">' + this.Name + '</a></li>');
                    
                //});

                //$('.panel-body').html('<p>Full name: <strong data-bind="text: fullName"></strong></p>');
                viewModel.updateDishes(data);
            }
        });
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
