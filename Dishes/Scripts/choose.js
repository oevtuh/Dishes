(function($) {
    $(".ingredients-list>li").change(selectDishes);

    function selectDishes() {
        var dishes = [];

        $("input[name='List']:checked").each(function() {
            dishes.push(+$(this).val());
        });


        $.ajax({
            url: 'FindByIngredients',
            type: 'get',
            data: {
                dishes: dishes
            },
            traditional: true,
            dataType: 'json',
            success: function (data) {
                $("#dishes_list").empty();
                $.each(data, function (i) {
                    $("#dishes_list").append("<li>" + this.Name + "</li>");
                });
            }
        });
    };


})(jQuery);







    

